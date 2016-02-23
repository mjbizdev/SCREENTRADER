using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ListAdditionandResult
{
     public class Stocks_A
    {
         
    }
}
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



        public void AddResult2StockList(string _symbl, double deltaprice)
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
    }

 public partial class DispatcherTimerStockPick
        {
                public DispatcherTimerStockPick()
                {
                     
                        DispatcherTimer timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromSeconds(1);
                        timer.Tick += timer_Tick;
                        timer.Start();
                }

                void timer_Tick(object sender, EventArgs e)
                {
                        lblTime.Content = DateTime.Now.ToLongTimeString();
                }
        }

      