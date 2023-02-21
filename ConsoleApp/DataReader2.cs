using ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class DataReader2
    {
        public DataSet Import(string fileToImport)
        {
            // Read to temporary object
            List<CSVRow> csvRows = ReadCsvFile(fileToImport);
            // convert to object tree
            DataSet dataSet = CreateDataSet(csvRows);
            return dataSet;
        }

        private List<CSVRow> ReadCsvFile(string fileToImport)
        {
            List<CSVRow> csvRows = new List<CSVRow>();
            using (var streamReader = new StreamReader(fileToImport))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    if (line.Trim().Length == 0)
                        continue;
                    var csvRow = new CSVRow(line);
                    csvRows.Add(csvRow);
                }
            }
            return csvRows;
        }

        private DataSet CreateDataSet(IEnumerable<CSVRow> csvRows)
        {
            DataSet dataSet = new DataSet();
            var databases = csvRows.Where(cr => cr.Type == Database.objectName)
                                   .OrderBy(r => r.Name);
            foreach (var db in databases)
            {
                var dbObj = CreateDatabaseObject(db, csvRows);
                dataSet.Databases.Add(dbObj);
            }
            return dataSet;
        }
        private Database CreateDatabaseObject(CSVRow databaseRow, IEnumerable<CSVRow> csvRows)
        {
            var database = new Database
            {
                Name = databaseRow.Name
            };

            // get tables for this database object
            var tables = csvRows.Where(cr => cr.Type == DataTable.objectName 
                                          && cr.ParentType == Database.objectName
                                          && cr.ParentName == database.Name)
                                .OrderBy(r => r.Schema + r.Name); ;
            foreach (var tab in tables)
            {
                var tableObj = CreateTableObject(tab, csvRows);
                database.Tables.Add(tableObj);
            }
            return database;
        }

        private DataTable CreateTableObject(CSVRow tableRow, IEnumerable<CSVRow> csvRows)
        {
            var dataTable = new DataTable
            {
                Name = tableRow.Name,
                Schema= tableRow.Schema
            };
            // get columns for this table object
            var columns = csvRows.Where(cr => cr.Type == DataColumn.objectName
                                          && cr.ParentType == DataTable.objectName
                                          && cr.Schema== tableRow.Schema
                                          && cr.ParentName == dataTable.Name)
                                 .OrderBy(r => r.Name);
            foreach (var col in columns)
            {
                var columnObj = new DataColumn
                {
                    Name = col.Name,
                    Schema = col.Schema,
                    DataType = col.DataType,
                    Nullable = col.IsNullable
                };
                dataTable.Columns.Add(columnObj);
            }
            return dataTable;
        }
    }
}
