namespace Adapter_Design;

public interface INotifier
{
    void Notify(string message);
}

public class SmsNotifier : INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class EmailNotifier : INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public class NotificationManager
{
    private readonly INotifier _notifier;

    public NotificationManager(INotifier notifier)
    {
        _notifier = notifier;
    }

    public void Send(string message)
    {
        _notifier.Notify(message);
    }
}

// External library: we don't own this code and can't modify it
public class WhatsAppService
{
    public void SendWhatsAppMessage(string text)
    {
        Console.WriteLine($"Sending WhatsApp: {text}");
    }
}

/*
 * Problem: We have a working notification system where every sender
 * (Email, SMS) implements INotifier with a Notify(string message) method,
 * and NotificationManager works with anything of that type.
 *
 * Now we want to add WhatsApp, but sending WhatsApp messages is done through
 * an external library, WhatsAppService, which exposes
 * SendWhatsAppMessage(string text) instead.
 *
 * It doesn't implement INotifier, so we can't plug it into our system
 * (compile error), and we can't modify it because we don't own the code.
 */


// Solution: We can create an adapter that implements INotifier and wraps
// the WhatsAppService, translating the Notify call into a SendWhatsAppMessage call.
public class WhatsAppServiceAdapter : INotifier
{
    private readonly WhatsAppService _whatsAppService;

    public WhatsAppServiceAdapter(WhatsAppService whatsAppService)
    {
        _whatsAppService =  whatsAppService;
    }
    public void Notify(string message)
    {
        _whatsAppService.SendWhatsAppMessage(message);
    }
}

public class Program
{
    public static void Main()
    {
        var emailManager = new NotificationManager(new EmailNotifier());
        emailManager.Send("Hello by Email");

        var smsManager = new NotificationManager(new SmsNotifier());
        smsManager.Send("Hello by SMS");

        // Before the adapter, this line would not compile:
        // var whatsAppManager = new NotificationManager(new WhatsAppService());
        // var whatsAppManager = new NotificationManager(new WhatsAppService());

        var whatsMessageManager = new NotificationManager(new WhatsAppServiceAdapter(new WhatsAppService()));
        whatsMessageManager.Send("Hello by WhatsApp");
    }
}