using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace ListAdditionandResult
{
    public struct Mediator
    {


    }




    public class GetxlData
    {
        public static System.Data.DataTable ExcelFreeRangeToDataTable(Microsoft.Office.Interop.Excel.Range range, string TableName)
        {
            object[,] valueArray = (object[,])range.Value2;

            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.TableName = TableName;


            dataTable.Columns.Add();// valueArray[1, colIndex].ToString()); //add columns to the data table.
            dataTable.Columns.Add();
            dataTable.Columns.Add();
            dataTable.Columns.Add();
            dataTable.Columns.Add();

            dataTable.Columns[0].ColumnName = "Symbol";
            dataTable.Columns[1].ColumnName = "smblQuote";
            dataTable.Columns[2].ColumnName = "change";
            dataTable.Columns[3].ColumnName = "volume";

            dataTable.Columns[0].DataType = typeof(object);
            dataTable.Columns[1].DataType = typeof(object);
            dataTable.Columns[2].DataType = typeof(object);
            dataTable.Columns[3].DataType = typeof(object);
            dataTable.Columns[4].DataType = typeof(object);

            //dataTable.Columns[0].DataType = typeof(string);
            //dataTable.Columns[1].DataType = typeof(object[,]);
            //dataTable.Columns[2].DataType = typeof(object[,]);
            //dataTable.Columns[3].DataType = typeof(object[,]);
            //dataTable.Columns[4].DataType = typeof(object[,]);
            // Load Excel SHEET DATA into data table
            object[] singleDValue = new object[valueArray.GetLength(1)];

            // Value array first row contains column names. so loop starts from 2 instead of 1
            for (int i = 1; i <= valueArray.GetLength(0); i++)
            {
                for (int j = 0; j < valueArray.GetLength(1); j++)
                {
                    if (valueArray[i, j + 1] != null)
                    {
                        singleDValue[j] = valueArray[i, j + 1].ToString();
                    }
                    else
                    {
                        singleDValue[j] = valueArray[i, j + 1];
                    }
                }
                dataTable.LoadDataRow(singleDValue, LoadOption.PreserveChanges);
            }
            return dataTable;
        }

        public static DataTable ExcelRangeToDataTable(Range range, string TableName)
        {
            object[,] valueArray = (object[,])range.Value2;

            DataTable dataTable = new DataTable();
            dataTable.TableName = TableName;

            for (int colIndex = 1; colIndex <= valueArray.GetLength(1); colIndex++)
            {
                dataTable.Columns.Add((string)valueArray[1, colIndex].ToString()); //add columns to the data table.
            }

            // Load Excel SHEET DATA into data table
            object[] singleDValue = new object[valueArray.GetLength(1)];

            // Value array first row contains column names. so loop starts from 2 instead of 1
            for (int i = 2; i <= valueArray.GetLength(0); i++)
            {
                for (int j = 0; j < valueArray.GetLength(1); j++)
                {
                    if (valueArray[i, j + 1] != null)
                    {
                        singleDValue[j] = valueArray[i, j + 1].ToString();
                    }
                    else
                    {
                        singleDValue[j] = valueArray[i, j + 1];
                    }
                }
                dataTable.LoadDataRow(singleDValue, LoadOption.PreserveChanges);
            }
            return dataTable;
        }
//        public void goforth()
//        {
//         int i = 0;
           
//            QuoteDataSet.DataSetName = "QuoteDataSet";
//            Microsoft.Office.Interop.Excel.Range rn = xlApp.get_Range("CurrentLiveDataQuotes");
//            QuoteDataSet.Tables.Add(GetxlData.ExcelFreeRangeToDataTable(xlApp.get_Range("CurrentLiveDataQuotes"), "GglStockQuotes"));
//            //  QuoteDataSet.Tables[0].Columns[0].ColumnName = "Symbol";
//            for (i = QuoteDataSet.Tables[0].Rows.Count - 1; i >= 0; i--)
//            {
//                if (QuoteDataSet.Tables[0].Rows[i][1] == DBNull.Value)
//                    QuoteDataSet.Tables[0].Rows[i].Delete();
//            }
//            var countem = CountDataset(QuoteDataSet);

//            dataGridView1.DataSource = QuoteDataSet.Tables[0];
//            dataGridView1.Update(); //.DataBind();

//            i = 0;
//            for (i = 0; i <= QuoteDataSet.Tables["GglStockQuotes"].Rows.Count - 1; i++)
//            {
//                textBox1.Text = textBox1.Text + QuoteDataSet.Tables[0].Rows[i].ItemArray[0] + " -- " +
//                                QuoteDataSet.Tables[0].Rows[i].ItemArray[1];
//            }
//            releaseObject(rn);
//}
//        public int  GetValue()
//        {
//            DateTime time = DateTime.Now;
//            Console.WriteLine("Building StockQuotes Dict {0}", time.ToShortTimeString());
//            StockQuotes.TryAdd("SPY", 186.14);
//            StockQuotes.TryAdd("PLUG", 7.08);
//            StockQuotes.TryAdd("FST", 1.89);
//            StockQuotes.TryAdd("BAC", 16.13);
//            StockQuotes.TryAdd("DGAZ", 3.22);
//            StockQuotes.TryAdd("RNN", 0.96);
//            StockQuotes.TryAdd("GRPN", 7.10);
//            StockQuotes.TryAdd("EWJ", 11.15);
//            StockQuotes.TryAdd("NLY", 11.41);
//            StockQuotes.TryAdd("BBRY", 7.15);


//            Console.WriteLine("Building StockQuotes0 -  OLD Dict {0}", time.ToShortTimeString());
//            StockQuotes0.TryAdd("SPY", 186.54);
//            StockQuotes0.TryAdd("PLUG", 7.68);
//            StockQuotes0.TryAdd("FST", 1.89);
//            StockQuotes0.TryAdd("BAC", 16.00);
//            StockQuotes0.TryAdd("DGAZ", 3.21);
//            StockQuotes0.TryAdd("RNN", 0.94);
//            StockQuotes0.TryAdd("GRPN", 7.10);
//            StockQuotes0.TryAdd("EWJ", 11.05);
//            StockQuotes0.TryAdd("NLY", 11.40);
//            StockQuotes0.TryAdd("BBRY", 7.26);


//            foreach (var pair in StockQuotes0)
//            {
//                Console.WriteLine("{0}", //", {1}",
//                    //pair.Key,
//                    pair.Value);
//                var list2 = new List<string>(StockQuotes0.Keys);
//                // listBox1.Items.AddRange(object);
//            }
//            //check to see if stock is in the dictiionary return double price if found or double 0 if not found 
//            Console.WriteLine("Calculate and Build Stock Differences- New -  OLD  Dict {0}", time.ToShortTimeString());
//            foreach (var pairZ in StockQuotes0)
//            {
//                string _symbolQ = pairZ.Key;

//                double getQuote = StockQuotes.ContainsKey(_symbolQ) ? StockQuotes[_symbolQ] : 982736;
//                double getQuote0 = StockQuotes0.ContainsKey(_symbolQ) ? StockQuotes0[_symbolQ] : 222222;
//                //if stock is not in list then do something 
//                // CALCULATE THE DIFFERENCE
//                double deltaprice = (getQuote - getQuote0);
//                double percentchange = deltaprice / getQuote;


//                Console.WriteLine("Stockquotes keyexists {0}", getQuote);
//                Console.WriteLine("Stockquotes0 keyexists {0}", getQuote0);
//                Console.WriteLine("Stockquotes deltaprice {0}", deltaprice);
//                Console.WriteLine("{1}  Stockquotes % change {0}", percentchange * 100, _symbolQ);
//                // put result into result dictionary list 
//                // StockDeltas.Clear();
//                var rtn = AddResult2StockList(_symbolQ, deltaprice);
//                Console.WriteLine("Stockquotes deltapricelist {1} verified  {0}", StockDeltas[_symbolQ], _symbolQ);
//            }

//            foreach (var pair in StockDeltas)
//            {
//                Console.WriteLine("StockDeltas  ***** = {0} {1}", //", {1}",
//                    pair.Key,
//                    pair.Value);
//                var list2 = new List<string>(StockQuotes0.Keys);
//            }
//            // put dictionary into text box  
//            foreach (var pair in StockDeltas)
//            {
//                Form1.textBox1.Text = textBox1.Text + "   " + pair.Key + "   " + pair.Value + "\r\n";
//            }
//            return 1;
//        }

//        public int getLiveData()
//        {

//            var CurrentPricedict = new ConcurrentDictionary<string, double>();
//            Microsoft.Office.Interop.Excel.Range rn = xlApp.get_Range("=DataLive!$A$1:$b$247");
//            object[,] rnvalues = rn.Value2;
//            int rowCountMAX = rn.Rows.Count;
//            int colCount = rn.Columns.Count;
//            int rowCounter = 1;
//            int colCounter = 1;

//            object[,] valueArray2 = (object[,])rn.Value2;
//            while (rowCounter < rowCountMAX)
//            {
//                colCounter = 1;

//                if (rnvalues[rowCounter, 1] != null)
//                {
//                    CurrentPricedict.TryAdd((rnvalues[rowCounter, 1].ToString()),
//                        Convert.ToDouble(rnvalues[rowCounter, 2]));
//                }


//                rowCounter++;
//            }
//            releaseObject(rn);
//            Console.WriteLine("made  CurrentPricedict list");


//            string _symbolQQ = CurrentPricedict.Count.ToString();
//            Console.WriteLine("attempt to write symbols, {0}", _symbolQQ);

//            foreach (var pair in CurrentPricedict)
//            {

//                string _symbolQq = pair.Key;
//                Console.WriteLine("made  CurrentPricedict  classic list  {0}", _symbolQq);
//                releaseObject(rn);
//            }
//            return 0;
            
//        }
    }
}
