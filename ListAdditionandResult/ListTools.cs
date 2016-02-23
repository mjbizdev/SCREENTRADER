using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Data;

namespace ListAdditionandResult
{
    public class Listmgmt
    {
        public ConcurrentDictionary<string, double> StockListAa { get; set; }
       // public ConcurrentDictionary<string, double> StockQuotes { get; set; }

        private ConcurrentDictionary<string, double> _StockDeltas_ = new ConcurrentDictionary<string, double>();
             private ConcurrentDictionary<string, double> _StockQuotes0_ = new ConcurrentDictionary<string, double>();
             private ConcurrentDictionary<string, double> _StockQuotes_ = new ConcurrentDictionary<string, double>();
        private ConcurrentDictionary<string, double> _StockList_ = new ConcurrentDictionary<string, double>();

        public ConcurrentDictionary<string, double> StockDeltas
        {
            get { return this._StockDeltas_; }
            set { _StockDeltas_ = value; }
        }

        public ConcurrentDictionary<string, double> StockQuotes
        {
            get { return this._StockQuotes_; }
            set { _StockQuotes_ = value; }
        }

        public ConcurrentDictionary<string, double> StockQuotes0
        {
            get { return this._StockQuotes_; }
            set { _StockQuotes_ = value; }
        }

        public ConcurrentDictionary<string, double> StockList
        {
            get { return this._StockList_; }
            set { _StockList_ = value; }
        }

        private DataSet QuoteDataSet = new DataSet();
     
        

        public  void AddResult2StockList(string _symbl, double deltaprice)
        {
            // must check for existence of symbol to avoid exception
            //  StockDeltas = new Dictionary<string, double>();
             StockDeltas.TryAdd(_symbl, deltaprice);
            double valuediff = StockList[_symbl];
            Console.WriteLine("StockFDelta {1} value= {0}", _symbl, valuediff);
            Console.WriteLine(" AddResult2list added  {1}  to stocklist at $ value= {0}", _symbl, valuediff);
          //  return 1800;

            //Console.WriteLine("Stockquotes deltapricelist {0}", StockList[_symbl]);
        }

 public void Buildlist ()
 {
      var StockQuotes = new ConcurrentDictionary<string, double>();
       DateTime time = DateTime.Now;
         Console.WriteLine 
    ("Building StockQuotes Dict {0}",time.ToShortTimeString ());
     var tryAdd = StockQuotes.TryAdd ("SPY", 186.14);
     StockQuotes.TryAdd ("PLUG", 7.08);
       StockQuotes.TryAdd ("FST", 1.89);
       StockQuotes.TryAdd ("BAC", 16.13);
         StockQuotes.TryAdd ("DGAZ", 3.22);
         StockQuotes.TryAdd("RNN", 0.96);
         StockQuotes.TryAdd ("GRPN", 7.10);
         StockQuotes.TryAdd ("EWJ", 11.15);
         StockQuotes.TryAdd ("NLY", 11.41);
         StockQuotes.TryAdd ("BBRY", 7.15);

         var StockQuotes0 = new ConcurrentDictionary<string, double>();
         Console.WriteLine 
    ("Building StockQuotes0 -  OLD Dict {0}",
         time.ToShortTimeString ());
         StockQuotes0.TryAdd ("SPY", 186.14);
         StockQuotes0.TryAdd ("PLUG", 7.08);
         StockQuotes0.TryAdd ("FST", 1.89);
         StockQuotes0.TryAdd ("BAC", 16.13);
         StockQuotes0.TryAdd ("DGAZ", 3.22);
         StockQuotes0.TryAdd ("RNN", 0.96);
         StockQuotes0.TryAdd ("GRPN", 7.10);
         StockQuotes0.TryAdd ("EWJ", 11.15);
         StockQuotes0.TryAdd ("NLY", 11.41);
         StockQuotes0.TryAdd ("BBRY", 7.15);
          
    foreach (
         var pair 
    in
         StockQuotes0 
    )
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
         var pair 
    in
         StockQuotes0 
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
        // StockDeltas.Clear();
        AddResult2StockList(_symbolQ, deltaprice);
        Console.WriteLine("Stockquotes deltapricelist {1} verified  {0}", StockDeltas[_symbolQ], _symbolQ);
    }

}

}
}
