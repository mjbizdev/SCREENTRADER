using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using System.Windows.Threading;
using ListAdditionandResult;
using System.Media;

public class SampleResults    : INotifyPropertyChanged
{

 

    

    public event PropertyChangedEventHandler PropertyChanged;
    public ConcurrentDictionary<string, double> StockQuotes0 = new ConcurrentDictionary<string, double>();
    public ConcurrentDictionary<string, double>  StockQuotes = new ConcurrentDictionary<string, double>();
    public List<string> CurrentTOPPicks { get; set; }

    public void MakeTestPortfolioList()
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
    }

}



public class TestLists : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public  ConcurrentDictionary<string, double> NewTopStocksDictionary = new ConcurrentDictionary<string, double>();

    public void Testlists()
    {

        BindingSource bindingSource1 = new BindingSource();
        DateTime time = DateTime.Now;

        Console.WriteLine();
        Console.WriteLine("Starting  -  Building Dummy StockQuotes Dict {0}", time.ToShortTimeString());
        NewTopStocksDictionary.TryAdd("SPY", 186.14);
        NewTopStocksDictionary.TryAdd("HURN", 16.13);
        NewTopStocksDictionary.TryAdd("FST", 1.89);
        NewTopStocksDictionary.TryAdd("BAC", 16.13);
        NewTopStocksDictionary.TryAdd("DGAZ", 3.22);
        NewTopStocksDictionary.TryAdd("RNN", 0.96);
        NewTopStocksDictionary.TryAdd("GRPN", 7.10);
        NewTopStocksDictionary.TryAdd("EWJ", 11.15);
        NewTopStocksDictionary.TryAdd("NLY", 11.41);
        NewTopStocksDictionary.TryAdd("BBRY", 7.15);
        Console.WriteLine();
        Console.WriteLine("Created StockQuotes Dict pair.key, pair.value style {0}", time.ToShortTimeString());
        foreach (var pair in NewTopStocksDictionary)
        {
            Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            // listBox1.Items.AddRange(object);
        }
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Created StockQuotes Dict just the ;pair: {0}", time.ToShortTimeString());
        foreach (var pair in NewTopStocksDictionary)
        {
            Console.WriteLine(pair);
        }
        Console.WriteLine();
        Console.WriteLine("Created StockQuotes Dict just the value {0}", time.ToShortTimeString());
        foreach (var key in NewTopStocksDictionary)
        {
            Console.WriteLine("{0}", key.Value.ToString());

            // listBox1.Items.AddRange(object);
        }
        Console.WriteLine();

        // Copy the  Stock Symbols from Dictionary to list  >>>  to quote later
        var list2 = new List<string>(NewTopStocksDictionary.Keys);
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
      //  dataGridView1.DataSource = fooList.ToList();
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

public  class DispatcherTimerStockPickr
{
    public DispatcherTimerStockPickr()
    {

        DispatcherTimer dttimer = new DispatcherTimer();
        dttimer.Interval = TimeSpan.FromSeconds(1);
        dttimer.Tick += timerz_Tick;
        dttimer.Start();
    }

    void timerz_Tick(object sender, EventArgs e)
    {
        lblTime.Content = DateTime.Now.ToLongTimeString();
    }
}

//public  static  mediaUtil
//{

        
//            using (SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav")) ;
//            simpleSound.Play;

        
//    }

