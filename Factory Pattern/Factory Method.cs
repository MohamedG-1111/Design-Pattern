//namespace Factory_Pattern;

//public interface INotify
//{
//    void Send(string message);
//}

//public class SMSNotifier : INotify
//{
//    public void Send(string message) => Console.WriteLine("SMS Message Sent");
//}

//public class EmailNotifier : INotify
//{
//    public void Send(string message) => Console.WriteLine("Email Message Sent");
//}

//public class GridEmailNotifier : INotify
//{
//    public void Send(string message) => Console.WriteLine("GridEmail Message Sent");

//}
//// Problem: New requirement: an order must send emails using two providers:
//// SMTP for order (transactional) emails, and SendGrid for marketing emails.
////public class OrderService
////{
////    public void NotifyCustomer(string channel, string message)
////    {
////        INotify notify;
////        if (channel == "email")
////            notify = new EmailNotifier();
////        else if (channel == "SMS")
////            notify = new SMSNotifier();
////        else
////            throw new ArgumentException($"Unsupported channel: {channel}");
////        notify.Send(message);
////    }
////}

//// Solution: Method Factory Pattern.
//public abstract class NotifyCreator
//{
//    public abstract INotify CreateNotifier();

//    public void Notify(string message)
//    {
//        var Notifier = CreateNotifier();
//        Notifier.Send(message);
//    }
//}

//public class MarketingNotifierCreator : NotifyCreator
//{
//    public override INotify CreateNotifier() => new SMSNotifier();
    
//}
//public class OrderNotifierCreator:NotifyCreator
//{
//    public override INotify CreateNotifier() => new GridEmailNotifier();

//}

//public static class OrderService
//{
//    public static void NotifyCustomer()
//    {
//        NotifyCreator  OrderNotitfier= new OrderNotifierCreator();
//        OrderNotitfier.Notify("Order");
//    }
//}