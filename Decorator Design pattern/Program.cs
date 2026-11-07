using System.Text;

namespace Decorator_Design_pattern;

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

public class LoggingDecorator : INotifier
{
    private readonly INotifier _notifier;

    public LoggingDecorator(INotifier notifier)
    {
        _notifier = notifier;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"Logging: {message}");
        _notifier.Notify(message);
    }
}

public class EncryptionDecorator : INotifier
{
    private readonly INotifier _notifier;

    public EncryptionDecorator(INotifier notifier)
    {
        _notifier = notifier;
    }

    public void Notify(string message)
    {
        Console.WriteLine($"Encryption: {message}");
        var encrypted = Convert.ToBase64String(Encoding.UTF8.GetBytes(message));
        _notifier.Notify(encrypted);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var emailNotifier = new EmailNotifier();
        var decoratedEmailNotifier = new LoggingDecorator(new EncryptionDecorator(emailNotifier));
        decoratedEmailNotifier.Notify("jdsnff");

        Console.WriteLine("------------------");

        var smsNotifier = new EncryptionDecorator(new LoggingDecorator(new SmsNotifier()));
        smsNotifier.Notify("jdsnff");
    }
}