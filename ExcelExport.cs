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
        Excel.Worksheet xlWorkSheet;

        public ExcelExport()
        {
            xlApp = new Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Error, Excel is not installed on this system!");
                return;
            }

            xlApp.Workbooks.Add(); ;
            xlWorkSheet = xlApp.ActiveSheet();
        }

        public void WriteTable(DataTable dt, string filename)
        {
            for (int colIndex = 0; colIndex < dt.Columns.Count; ++colIndex)
                xlWorkSheet.Cells[1, (colIndex + 1)] = dt.Columns[colIndex].ColumnName;

            for (int rowIndex = 0; rowIndex < dt.Rows.Count; ++rowIndex)
            {
                for (int colIndex = 0; colIndex < dt.Columns.Count; ++colIndex)
                {
                    xlWorkSheet.Cells[(rowIndex+2),(colIndex+1)] = dt.Rows[rowIndex][colIndex];
                }
            }

            try
            {
                xlWorkSheet.SaveAs(filename);
                xlApp.Quit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
