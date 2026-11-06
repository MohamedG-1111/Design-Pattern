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

//// Problem: every time we add a new notifier, we have to open and modify this method.
//// This violates the Open/Closed Principle (OCP).
////
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

//// Solution: Simple Factory Pattern.
//// Object creation is moved into the factory, so OrderService no longer knows concrete notifiers.
//public static class NotifyFactory
//{
//    public static INotify Create(string channel)
//        => channel?.ToLowerInvariant() switch
//        {
//            "email" => new EmailNotifier(),
//            "sms" => new SMSNotifier(),
//            _ => throw new ArgumentException($"Unsupported channel: {channel}", nameof(channel))
//        };
//}

//public class OrderService
//{
//    public void NotifyCustomer(string channel, string message)
//    {
//        NotifyFactory.Create(channel).Send(message);
//    }
//}