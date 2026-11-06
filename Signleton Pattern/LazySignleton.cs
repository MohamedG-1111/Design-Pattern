using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signleton_Pattern
{
    internal class LazySignleton
    {
    }
    //public class FileLogger
    //{
    //    private static FileLogger _instance;
    //    private static Lock _lock = new Lock();
    //    public static FileLogger Instance
    //    {
    //        set
    //        {
    //            if (_instance == null)
    //                lock (_lock)
    //                {
    //                    if (_instance == null)
    //                        _instance = new FileLogger();
    //                }
    //        }
    //        get
    //        {
    //            return _instance;
    //        }
    //    }
    //    public static int x = 10;

    //    private static StreamWriter _StreamWriter;

    //    private FileLogger()
    //    {
    //        Console.WriteLine("Create Object When Acess  Instance Only ");

    //        _StreamWriter = new StreamWriter("app.txt", true);
    //        _StreamWriter.WriteLine("======= Logger ==========");
    //    }

    //    public void Log(string message)
    //    {
    //        lock (_lock)
    //        {
    //            _StreamWriter.WriteLine(message);
    //        }

    //    }
    //}
    

    // Using Lazy In c# 9
    public class FileLogger
    {
        private static Lazy<FileLogger> _instance=
            new Lazy<FileLogger>(() => new FileLogger());
        public static int x = 10;

        private static StreamWriter _StreamWriter;

        private FileLogger()
        {
            Console.WriteLine("Create Object When Acess  Instance Only ");

            _StreamWriter = new StreamWriter("app.txt", true);
            _StreamWriter.WriteLine("======= Logger ==========");
        }
        private static Lock _lock = new Lock();

        public void Log(string message)
        {
            lock (_lock)
            {
                _StreamWriter.WriteLine(message);
            }

        }
    }
    public class OrderService
    {
        public void CreateOrder()
        {
            FileLogger.Instance.Log("Order Created");
        }
        public void GetX()
        {
            Console.WriteLine(FileLogger.x);
        }
    }
}
