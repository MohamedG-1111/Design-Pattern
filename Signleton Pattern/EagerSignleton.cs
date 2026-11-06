using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Signleton_Pattern
{
    internal class EagerSignleton
    {
    }
    //public class FileLogger
    //{
    //    private static readonly FileLogger _instance = new FileLogger();
    //    public static FileLogger Instance => _instance;
    //    private static StreamWriter _StreamWriter;
    //    public  static int x = 10;
    //    private Lock _lock = new Lock();
    //    private FileLogger()
    //    {
    //        Console.WriteLine("Create Object When Acess Any Thing in class");
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
    //public class OrderService
    //{
    //    //public void CreateOrder()
    //    //{
    //    //    FileLogger.Instance.Log("Order Created");
    //    //}

    //    public void GetX()
    //    {
    //        Console.WriteLine( FileLogger.x);
    //    }
    //}
}