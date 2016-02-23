namespace ListAdditionandResult
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class BuildTestPortfolio
    {
      
        public  void MakeList1()
        {
            MakeTestPortfolioList();
              // Set up collections 

        // Delcare Excel Objects
 

        //  public string xlfileName2 = "C:\\temp\\ScoreKeeper2.xlsm";

        }
        public void releaseExcelobjj()
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
        private  void MakeTestPortfolioList()
        {

            DateTime time = DateTime.Now;
            Console.WriteLine
                ("Building StockQuotes Dict {0}", time.ToShortTimeString());
            var tryAdd = StockQuotes.TryAdd("SPY", 186.14);
            StockQuotes.TryAdd("PLUG", 7.08);
            StockQuotes.TryAdd("FST", 1.89);
            StockQuotes.TryAdd("BAC", 16.13);
            StockQuotes.TryAdd("DGAZ", 3.22);
            StockQuotes.TryAdd("RNN", 0.96);
            StockQuotes.TryAdd("GRPN", 7.10);
            StockQuotes.TryAdd("EWJ", 11.15);
            StockQuotes.TryAdd("NLY", 11.41);
            StockQuotes.TryAdd("BBRY", 7.15);

            var StockQuotes0 = new ConcurrentDictionary<string, double>();
            Console.WriteLine
                ("Building StockQuotes0 -  OLD Dict {0}",
                    time.ToShortTimeString());
            StockQuotes0.TryAdd("SPY", 186.14);
            StockQuotes0.TryAdd("PLUG", 7.08);
            StockQuotes0.TryAdd("FST", 1.89);
            StockQuotes0.TryAdd("BAC", 16.13);
            StockQuotes0.TryAdd("DGAZ", 3.22);
            StockQuotes0.TryAdd("RNN", 0.96);
            StockQuotes0.TryAdd("GRPN", 7.10);
            StockQuotes0.TryAdd("EWJ", 11.15);
            StockQuotes0.TryAdd("NLY", 11.41);
            StockQuotes0.TryAdd("BBRY", 7.15);

            foreach (var pair in StockQuotes0)
            {
                Console.WriteLine("{0}", //", {1}",
                    //pair.Key,
                    pair.Value);
                var list2 = new List<string>(StockQuotes0.Keys);
                // listBox1.Items.AddRange(object);
            }
            //check to see if stock is in the dictiionary return double price if found or double 0 if not found 
            Console.WriteLine
                ("Calculate and Build Stock Differences- New -  OLD  Dict {0}",
                    time.ToShortTimeString());
            foreach (
                var pair in StockQuotes0
                )
            {
                string _symbolQ = pair.Key;

                double getQuote = StockQuotes.ContainsKey(_symbolQ) ? StockQuotes[_symbolQ] : 982736;
                double getQuote0 = StockQuotes0.ContainsKey(_symbolQ) ? StockQuotes0[_symbolQ] : 222222;
                //if stock is not in list then do something 
                // CALCULATE THE DIFFERENCE
                double deltaprice = (getQuote - getQuote0);
                double percentchange = deltaprice/getQuote;


                Console.WriteLine("Stockquotes keyexists {0}", getQuote);
                Console.WriteLine("Stockquotes0 keyexists {0}", getQuote0);
                Console.WriteLine("Stockquotes deltaprice {0}", deltaprice);
                Console.WriteLine("{1}  Stockquotes % change {0}", percentchange*100, _symbolQ);
                // put result into result dictionary list 
                //   // StockDeltas.Clear();
                //  AddResult2StockList(_symbolQ, deltaprice);
                // Console.WriteLine("Stockquotes deltapricelist {1} verified  {0}", Listmgmt.Stockdeltas[_symbolQ], _symbolQ);
            }
        }
    }
}