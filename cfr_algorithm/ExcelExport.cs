using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace cfr_algorithm
{
    class ExcelExport
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkbook;
        Excel.Worksheet xlWorksheet;
        
        public ExcelExport()
        {
            
        }

        private bool StartExcel()
        {
            xlApp = new Excel.Application();
            
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not installed on this system!");
                return false;
            }
            
            xlApp.Visible = false;
            xlWorkbook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
            xlWorksheet = xlWorkbook.ActiveSheet;

            return true;
        }

        private void StopExcel()
        {
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
        }

        public void WriteTable(DataTable dt, string filename)
        {
            if (!StartExcel())
                return;

            // Fill headers
            for (int colIndex = 0; colIndex < dt.Columns.Count; ++colIndex)
                xlWorksheet.Cells[1, (colIndex + 1)] = dt.Columns[colIndex].ColumnName;

            // Write data
            for (int rowIndex = 0; rowIndex < dt.Rows.Count; ++rowIndex)
            {
                for (int colIndex = 0; colIndex < dt.Columns.Count; ++colIndex)
                {
                    xlWorksheet.Cells[(rowIndex+2),(colIndex+1)] = dt.Rows[rowIndex][colIndex];
                }
            }

            xlWorksheet.SaveAs(filename);
            StopExcel();
        }
    }
}
