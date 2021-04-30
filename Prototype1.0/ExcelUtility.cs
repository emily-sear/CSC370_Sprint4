using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows;

namespace Prototype1._0
{

    /** 
     * This code is from https://www.c-sharpcorner.com/uploadfile/deveshomar/exporting-datatable-to-excel-in-c-sharp-using-interop/
     * All credits/rights go to this author. 
     **/
    class ExcelUtility
    {

        public bool WriteDataTableToExcel(System.Data.DataTable dataTable, string worksheetName, string saveAsLocation, string ReporType)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellRange;

            try
            {
                //Start Excel and get the Application Object
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel Visible
                excel.Visible = true;
                excel.DisplayAlerts = false;

                excelWorkbook = excel.Workbooks.Add(Type.Missing);
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.ActiveSheet;
                excelSheet.Name = worksheetName;

                excelSheet.Cells[1, 1] = ReporType;
                excelSheet.Cells[1, 2] = "Date: " + DateTime.Now.ToShortDateString();

                // loop through each row and add values to our sheet 
                int rowCount = 2; 

                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowCount++;

                    for(int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        //on the first iteration we add the colum headers 
                        if(rowCount == 3)
                        {
                            excelSheet.Cells[2, i] = dataTable.Columns[i - 1].ColumnName;
                            excelSheet.Cells.Font.Color = System.Drawing.Color.Black;
                        }

                        excelSheet.Cells[rowCount, i] = datarow[i - 1].ToString();

                        //for all other rows 
                        if(rowCount > 3)
                        {
                            if(i == dataTable.Columns.Count)
                            {
                                excelCellRange = excelSheet.Range[excelSheet.Cells[rowCount, 1], excelSheet.Cells[rowCount, dataTable.Columns.Count]];
                                FormattingExcelCells(excelCellRange, "#CCCCFF", System.Drawing.Color.Black, false);
                            }
                        }
                    }
                }

                // resizing the columns 
                excelCellRange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowCount, dataTable.Columns.Count]];
                excelCellRange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = excelCellRange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

                excelCellRange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[2, dataTable.Columns.Count]];
                FormattingExcelCells(excelCellRange, "#000099", System.Drawing.Color.White, true);

                //save the workbook and exit Excel 
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not convert dataTable to an Excel File. Please make sure that there is something in the DataTable. \nOriginal error " + ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellRange = null;
                excelWorkbook = null;
            }
        }

        public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool isFontBool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);

            if(isFontBool == true)
            {
                range.Font.Bold = isFontBool;
            }
        }

            
    }
}
