using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ListAdditionandResult
{

    public partial class Form1 : Form
    {
        private Excel.Worksheet mySheet;
        // private Excel.Workbook xlWKB;


        
        // ReSharper disable once InconsistentNaming
        



       
        
        public void InjectFormulaFillDown(ref Excel.Workbook xlWorkBooktoUse, ref Excel.Worksheet wkStoInjectWorksheet,ref string injectedFormula, ref Excel.Range CelltoInject,  ref Excel.Range rangetoFill)
        {
            //Add Worksheet 
            Excel.Worksheet newWorksheet;
            bool found = false;
            // Loop through all worksheets in the workbook
            foreach (Excel.Worksheet sheet in xlWorkBooktoUse.Sheets)
            {
                // Check the name of the current sheet
                if (sheet.Name == "Tester")
                {
                    found = true;
                    break; // Exit the loop now
                }
            }

            if (found)
            {
                // Reference it by name

               // Excel.Worksheet newWorksheet = xlWorkBooktoUse.Sheets["Tester"];
            }

            else
            {

                newWorksheet = xlWorkBooktoUse.Sheets.Add();
                newWorksheet.Name = "Tester";
                newWorksheet.Activate();

            }
            newWorksheet = mySheet;
            //Excel.Worksheet newWorksheet;
            //newWorksheet = xlApp.Worksheets.Add();
            //newWorksheet.Name = "Tester";
            //newWorksheet.Activate();
            //insert formula 

            Excel.Range ws44 = newWorksheet.get_Range("A10");
            string _injectedFormula = injectedFormula;

            //rn43.get_Item(0);
            Excel.Range rn45 = newWorksheet.get_Range("A10", "A20");
            rn45.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, _injectedFormula);
            // fill Down 
            // set named range 


            newWorksheet.Activate();
            rn45 = newWorksheet.get_Range("A10", "A20");

            rn45.FillDown();
            releaseObjects(rn45);
            releaseObjects(ws44);
            releaseObjects(newWorksheet);
           //releaseObjects(mySheet);
        }

        public void releaseObjects(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
