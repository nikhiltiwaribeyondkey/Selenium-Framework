using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using OfficeOpenXml;


namespace SeleniumC_Framework.utilities
{
    internal class ExcelDataReader
    {
        public static DataTable ExcelTableDataReader(string fileName)
        {

            
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelreader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet resulSet = excelreader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true

                }
            });

            DataTableCollection table = resulSet.Tables;
            DataTable resultTable = table["Test"];

            return resultTable;





        }


        public class DataCollection
        {
            public int rowNumber { get; set; }
            public String columnName { get; set; }
            public String columnvalue { get; set; }
            List<DataCollection> dataCollection = new List<DataCollection>();

            public void collectInCollection(string fileName)
            {

                DataTable table = ExcelDataReader.ExcelTableDataReader(fileName);
                if (table == null)
                {
                    TestContext.Progress.WriteLine("Error: The Excel table could not be loaded.");
                    return;
                }
               

                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        DataCollection dtCollection = new DataCollection()
                        {
                            rowNumber = row,
                            columnName = table.Columns[col].ColumnName,
                            columnvalue = table.Rows[row - 1][col].ToString()

                        };
                        dataCollection.Add(dtCollection);
                    }

                }

            }

            public string ReadData(int row, string column)
            {
                try
                {
                    String data = (from columnData in dataCollection
                                   where columnData.columnName == column && columnData.rowNumber == row
                                   select columnData.columnvalue).SingleOrDefault();

                    if (data == null)
                    {
                        TestContext.Progress.WriteLine("Data Null " );
                        return null;
                    }
                    return data.ToString();
                }
                catch(Exception exception) {
                    TestContext.Progress.WriteLine("exception" + exception.Message);

                    return null;

                }
            }


             public void UpdateExcelFile(string filePath, string worksheetName, int rowNumber, string columnName, string newValue)
            {



                // Set the EPPlus License Context (required for EPPlus 5+)
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Update the Excel file
                //UpdateExcelFile(filePath);

                // Open the Excel package (this opens the existing file)
                FileInfo fileInfo = new FileInfo(filePath);

                Console.WriteLine("Full File Name- "+ fileInfo);
                // Open the Excel file using EPPlus
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    // Get the worksheet by name (e.g., "Test")
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Test"];

                    // Check if the worksheet exists
                    if (worksheet == null)
                    {
                        Console.WriteLine("Error: The sheet 'Test' was not found.");
                        TestContext.Progress.WriteLine("Error: The sheet 'Test' was not found.");
                        return;
                    }


                    var rowIndex = rowNumber;
                    if (rowNumber < 1 || rowIndex > worksheet.Dimension.Rows)
                    {
                        TestContext.Progress.WriteLine("Invalid Row");
                        throw new ArgumentException("Invalid Row");
                    }
                    var column = worksheet.Cells[1, 1, 1, worksheet.Dimension.Columns].FirstOrDefault(c => c.Text == columnName);

                    if (column == null)
                    {
                        TestContext.Progress.WriteLine("Invalid Column");
                        throw new ArgumentException("Invalid Column");
                    }

                    worksheet.Cells[rowIndex + 1, column.Start.Column].Value = newValue;
                    package.SaveAs(new FileInfo(filePath));

                    //// Example 1: Update a specific cell value
                    //worksheet.Cells["B2"].Value = "Updated Value"; // Update cell B2 with a new value

                    //// Example 2: Update a value by row and column index
                    //int row = 1;
                    //int column = 4;
                    //worksheet.Cells[row, column].Value = "New Value at Row 3, Column 4";

                    //// Example 3: Update an entire column (e.g., Column B)
                    //for (int i = 1; i <= worksheet.Dimension.End.Row; i++) // Loop through all rows
                    //{
                    //    worksheet.Cells[i, 2].Value = "Updated Column B"; // Update column B
                    //}

                    //// Example 4: Add a new row at the end of the sheet
                    //int newRow = worksheet.Dimension.End.Row + 1; // Get the last row number and add 1
                    //worksheet.Cells[newRow, 1].Value = "New Data"; // Add data to the new row

                    //// Save the changes to the existing Excel file
                    //package.Save();
                }
                //}

            }


        }


        //public class UdateExcelClass
        //{


    }
}



