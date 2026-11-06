namespace Signleton_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            OrderService orderService = new OrderService();
            orderService.GetX();
        }
    }
}
