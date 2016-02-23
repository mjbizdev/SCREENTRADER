using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Markup;
using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Core;
using System.Diagnostics;
using System.Collections;
using System.Threading;
using System.Xml.Serialization;
using System.Collections.Specialized;
using System.Net;
using System.Collections.Concurrent;
//using Jarloo.CardStock.Views;


namespace ListAdditionandResult
{
    using System.Collections.ObjectModel;
    using System.Media;
    using System.Security.Cryptography.X509Certificates;



    public partial class Form1 : Form
    {
        // Set up collections 

        // Delcare Excel Objects
        public Microsoft.Office.Interop.Excel.Application xlApp;
        public Microsoft.Office.Interop.Excel.Workbook xlWKB;
        public Microsoft.Office.Interop.Excel.Range xlRN1;
        public Microsoft.Office.Interop.Excel.Range xlRN2;
        public Microsoft.Office.Interop.Excel.Worksheet xlSheet;
        public Microsoft.Office.Interop.Excel.Sheets xlSheets;
        private object oMissing = System.Reflection.Missing.Value;
        // set Filenames for spreadsheets
        public string xlfileName1 = @"C:\temp\ScoreKeeper1.xlsm";
        public string strRange1NameA = "StockListA";
        public string strRange1NameB = "StockListB";

        //  public string xlfileName2 = "C:\\temp\\ScoreKeeper2.xlsm";
        //private Hashtable myHashtable;
        // Application Misc



        private const string Title = "GetRange Test";


        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            ExcelSetup();
        }

        public void ExcelSetup()
        {
            xlApp = new Excel.Application();
            xlWKB = xlApp.Workbooks.Open(xlfileName1);
            xlWKB.Activate();
            xlApp.Visible = true;
            xlSheets = xlWKB.Worksheets;
            string mySHeet = "EnterStocks";
            xlSheet = (Excel.Worksheet) xlSheets.get_Item(mySHeet);
            xlRN1 = (Excel.Range) xlSheet.get_Range(strRange1NameA);
        }

        #region ReleaseObject
        public void ReleaseObject(object obj)
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
                GC.WaitForPendingFinalizers();
            }
        }

        #endregion


        public void button1_Click(object sender, EventArgs e)
        {
            TestLists();
        }

        public void TestLists()
        {

            BindingSource bindingSource1 = new BindingSource();
            DateTime time = DateTime.Now;
            Listmgmt fooList = new Listmgmt();
            Console.WriteLine();
            Console.WriteLine("Starting  -  Building Dummy StockQuotes Dict {0}", time.ToShortTimeString());
            fooList.StockQuotes.TryAdd("SPY", 186.14);
            fooList.StockQuotes.TryAdd("HURN", 16.13);
            fooList.StockQuotes.TryAdd("FST", 1.89);
            fooList.StockQuotes.TryAdd("BAC", 16.13);
            fooList.StockQuotes.TryAdd("DGAZ", 3.22);
            fooList.StockQuotes.TryAdd("RNN", 0.96);
            fooList.StockQuotes.TryAdd("GRPN", 7.10);
            fooList.StockQuotes.TryAdd("EWJ", 11.15);
            fooList.StockQuotes.TryAdd("NLY", 11.41);
            fooList.StockQuotes.TryAdd("BBRY", 7.15);
            Console.WriteLine();
            Console.WriteLine("Created StockQuotes Dict pair.key, pair.value style {0}", time.ToShortTimeString());
            foreach (var pair in fooList.StockQuotes)
            {
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
                // listBox1.Items.AddRange(object);
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Created StockQuotes Dict just the ;pair: {0}", time.ToShortTimeString());
            foreach (var pair in fooList.StockQuotes)
            {
                Console.WriteLine(pair);
            }
            Console.WriteLine();
            Console.WriteLine("Created StockQuotes Dict just the value {0}", time.ToShortTimeString());
            foreach (var key in fooList.StockQuotes)
            {
                Console.WriteLine("{0}", key.Value.ToString());

                // listBox1.Items.AddRange(object);
            }
            Console.WriteLine();

            // Copy the  Stock Symbols from Dictionary to list  >>>  to quote later
            var list2 = new List<string>(fooList.StockQuotes.Keys);
            Console.WriteLine();
            Console.WriteLine("Created StockSymbolcs list only tickers from dict {0}", time.ToShortTimeString());
            foreach (var ww in list2)
            {
                Console.WriteLine("{0}", ww);

                // listBox1.Items.AddRange(object);
            }
            //    Listmgmt.StockQuotes = """;
            // copy dictionary to public property
            Console.WriteLine();
            Console.WriteLine("Finished Building Dummy StockQuotes Dict {0}", time.ToShortTimeString());
            dataGridView1.DataSource = fooList.StockQuotes.ToList();
            //  dataGridView1.
            dataGridView1.Refresh();

            Console.WriteLine("Created concurrent list just the tickers {0}", time.ToShortTimeString());
            var QuoteTest = new ObservableCollection<Quote>();
            //  QuoteTest = list2.ToList();
            foreach (var ww in list2)
            {
                QuoteTest.Add(new Quote(ww));

                // listBox1.Items.AddRange(object);
            }
            foreach (var ww in QuoteTest)
            {
                Console.WriteLine("{0}", ww.Symbol);

                // listBox1.Items.AddRange(object);
            }
            Console.WriteLine("Created concurrent list just the tickers {0}", time.ToShortTimeString());

            YahooStockEngine.Fetch(QuoteTest);
            //  dataGridView2.DataBindings.Add(Quote);
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            // Automatically generate the DataGridView columns.
            dataGridView1.AutoGenerateColumns = true;

            // Set up the data source.
            // bindingSource1.DataSource = Quo
            // dataGridView2.DataSource = bindingSource1;

            // Automatically resize the visible rows.
            dataGridView2.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            // Set the DataGridView control's border.
            dataGridView2.BorderStyle = BorderStyle.Fixed3D;

            // Put the cells in edit mode when user enters them.
            dataGridView2.EditMode = DataGridViewEditMode.EditOnEnter;
            //   dataGridView2.DataSource = CardDeckViewModel();
        }

        #region rangetodataSet
        //xlRN1 = xlApp.get_Range("StocksListA");
        //xlRN2 = xlApp.get_Range("StocksListB");
        //  //xlWKS = xlApp.Sheets["Results"];
        //  DataSet webDataSet = new DataSet();
        //  webDataSet.DataSetName = "Scores Data Set";

        //  // Excel Authoring Note: Ensure first column of each row must be valid column name and used as header
        //  // (must be unique within table.)
        //  webDataSet.Tables.Add(GetxlData.ExcelRangeToDataTable(xlApp.get_Range("_scoresLongA"), "Scores Long A"));
        //  webDataSet.Tables.Add(GetxlData.ExcelRangeToDataTable(xlApp.get_Range("_scoresShortA"), "Scores Short A"));
        //  webDataSet.Tables.Add(GetxlData.ExcelRangeToDataTable(xlApp.get_Range("_scoresLongB"), "Scores Long B"));
        //  webDataSet.Tables.Add(GetxlData.ExcelRangeToDataTable(xlApp.get_Range("_scoresShortB"), "Scores Short B"));
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
       //   YahooStockEngine(resu)
            
            //dataGridView2.DataSource 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Form1_UnLoad(object sender, EventArgs e)
        {
            xlRN1 = null;
            xlRN2 = null;
            xlSheet = null;
            xlSheets = null;
            xlWKB = null;
            xlWKB.Close(false, oMissing, oMissing);
            xlApp.DisplayAlerts = false;
            xlApp.Quit();
            xlApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private static string CountDataset(DataSet quoteDataSet)
        {
            string countem = quoteDataSet.Tables[0].Rows.Count.ToString();
            Console.WriteLine("There are {0} elements in dataset {1}", countem, quoteDataSet.DataSetName.ToString());
            return countem;
        }

        public void button4_Click(object sender, EventArgs e)
        {

            //Quotes.Add(new Quote("AAPL"));


        }



        private void button7_Click(object sender, EventArgs e)
        {
            RangeAtoList();
        }

        #region RangetoListA
        //    ExceltargetSpec(Excel.Worksheet sheetRangeisON, Excel.Excel.Range rangetosendto )
        //public void ListtoRange(ref List<string> reGliST, ref ExceltargetSpec )

        public void RangeAtoList()
        {
            // get excel range to use
            List<string> listempty = new List<string>();
            var MyList = GetValue(ref xlRN1, ref listempty);

            Console.WriteLine("This is a list from an Excel range");
            Console.WriteLine("made list of range   {0}", "foo");

            //  items.ForEach(point => point.X = point.X - 10);

            foreach (string s in MyList)
            {
                Console.WriteLine(s);
            }
            ReleaseObject(xlRN1);
        }

        #endregion
        public ObservableCollection<Quote> theresultsList { get; set; }
        public List<string> GetValue(ref Excel.Range rnS, ref  List<string> foo3)
        {

            //   object[,] rnvalues = rnS.Value2;
            int rowCountMAX = rnS.Rows.Count;
            Console.WriteLine("Count of Spreadsheet Range is  {0}", rowCountMAX);
            int colCount = rnS.Columns.Count;
            Console.WriteLine("Count of Spreadsheet COlumns is  {0}", colCount);
            Console.WriteLine("made list");

            object[,] cellValues = (object[,])rnS.Value2;
            foo3 = cellValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));
            return foo3;
            ReleaseObject(rnS);
        }

        public void button9_Click(object sender, EventArgs e)
        {
            BuildTestPortfolio.MakeList1();
            //  YahooStockEngine.Fetch(Sto);
        }

        public void button10_Click(object sender, EventArgs e)
        {
            BuildTestPortfolio.MakeList1();
        }


        private void Buildlist()
        {
            //   ListTools.Listmgmt.
        }

        private void Compare_1()
        {
            var oldpricedict = new ConcurrentDictionary<string, double>(StringComparer.Ordinal);
            double SPYdelta = 0;
            Microsoft.Office.Interop.Excel.Range rn = xlApp.get_Range("DataLive!$N$1:o$300");
            object[,] rnvalues = rn.Value2;
            int rowCountMAX = rn.Rows.Count;
            int colCount = rn.Columns.Count;
            int rowCounter = 1;
            int colCounter = 1;

            object[,] valueArray2 = (object[,])rn.Value2;
            while (rowCounter < rowCountMAX)
            {
                colCounter = 1;

                if (rnvalues[rowCounter, 1] != null)
                {
                    oldpricedict.TryAdd((rnvalues[rowCounter, 1].ToString()),
                        Convert.ToDouble(rnvalues[rowCounter, 2]));
                }


                rowCounter++;
            }
            ReleaseObject(rn);

            Console.WriteLine("made list");


            string _symbolQQ = oldpricedict.Count.ToString();
            var CurrentPricedict = new ConcurrentDictionary<string, double>();
            Microsoft.Office.Interop.Excel.Range rn2 = xlApp.get_Range("=DataLive!$A$1:$b$247");
            object[,] rnvalues2s = rn2.Value2;
            int rowCountMAX2 = rn2.Rows.Count;
            int colCount2 = rn2.Columns.Count;
            int rowCounter2 = 1;
            int colCounter2 = 1;

            object[,] valueArray2s = (object[,])rn.Value2;
            while (rowCounter2 < rowCountMAX2)
            {
                colCounter = 1;

                if (rnvalues[rowCounter2, 1] != null)
                {
                    CurrentPricedict.TryAdd((rnvalues2s[rowCounter2, 1].ToString()),
                        Convert.ToDouble(rnvalues2s[rowCounter2, 2]));
                }
                rowCounter2++;
            }
            ReleaseObject(rn2);
            var CurrentDeltas = new ConcurrentDictionary<string, double>();
            double value2;
            double value1;
            SPYdelta = CurrentDeltas.GetOrAdd("SPY", 999999.00);
            Parallel.ForEach(CurrentPricedict, pair4 =>
            {
                string stocknews = pair4.Key;
                double newPrice4 = pair4.Value;
                oldpricedict.TryGetValue(stocknews, out value1);
                value2 = (newPrice4 - value1);
                CurrentDeltas.TryAdd(stocknews, value2);
                Console.WriteLine("Deltas are {0} {1}", stocknews, value2);
            });
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        public void button11_Click(object sender, EventArgs e)
        {
            releaseExcelobj();
        }

        private void releaseExcelobj()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //  Marshal.FinalReleaseComObject(xlRange);
            //   Marshal.FinalReleaseComObject(xlSheets);

            //  / xlWKB.Close(Type.Missing, Type.Missing, Type.Missing);
            if (xlWKB != null) Marshal.FinalReleaseComObject(xlWKB);
            if (xlRN1 != null) Marshal.FinalReleaseComObject(xlRN1);
            if (xlRN2 != null) Marshal.FinalReleaseComObject(xlRN2);
            if (xlSheets != null) Marshal.FinalReleaseComObject(xlSheets);
            if (xlSheet != null) Marshal.FinalReleaseComObject(xlSheet);
            xlApp.Quit();
            if (xlApp != null) Marshal.FinalReleaseComObject(xlApp);
            xlApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //xlWKB = xlApp.Workbooks.Open(xlfileName);
            // xlSheets = xlWKB.Sheets("Tester");

            //   InjectFormulaFillDown(ref xlWKB, xlSheetslSheets, "=tested **********************", "c2", "c10");

        }

        public Excel.Worksheet xlSheetslSheets { get; set; }

        private void button13_Click(object sender, EventArgs e)
        {
            {
                SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                simpleSound.Play();
            }
        }

        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xlSheets != null) ReleaseObject(xlSheets);
            if (xlRN1 != null) ReleaseObject(xlRN1);
            if (xlRN2 != null) ReleaseObject(xlRN2);
            if (xlSheet != null) ReleaseObject(xlSheet);
            if (xlWKB != null) ReleaseObject(xlWKB);
            if (xlSheets != null) ReleaseObject(xlSheets);
            xlRN1 = null;
            xlRN2 = null;
            xlSheets = null;
            xlWKB = null;

            xlApp.DisplayAlerts = false;
            xlWKB.Close(true);
            // if (xlRange != null) releaseObject(xlRange);
            //    if (rn != null) releaseObject(rn);

            if (xlSheets != null) ReleaseObject(xlSheets);
            if (xlWKB != null) ReleaseObject(xlWKB);
            //  if (xlWKBs != null) releaseObject(xlWKB);
            if (xlApp != null) ReleaseObject(xlApp);
            releaseExcelobj();
            //  
            xlApp.Quit();
            //    xlRN1 = xlApp.get_Range("StocksListA");
            //    xlRN2 = xlApp.get_Range("StocksListB");
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }


    }
}

















