namespace Factory_Pattern;

/*
 We used the Abstract Factory Pattern to decouple the creation of Email and SMS services from the business logic,
allowing us to switch between Cloud and Internal providers without changing the code that uses these services.
It also ensures consistency between related services and helps prevent mixing incompatible implementations from different families.
For example, when using CloudMessage, we get TwilioSms and SmptEmail,
while InternalMessage provides CompanySms and SendGridEmail.
This reduces configuration mistakes and keeps the application flexible and maintainable.
 */
public interface ISmsNotifier
{
    void NotifySmsMessage(string message);
}
public interface IEmailNotifier
{
    void NotifyEmailMessage(string message);
}
public class CompanySms : ISmsNotifier
{
    public void NotifySmsMessage(string message)
    {
        Console.WriteLine(message);
    }
}
public class TwilioSms : ISmsNotifier
{
    public void NotifySmsMessage(string message)
    {
        Console.WriteLine(message);
    }
}
public class SmptEmail : IEmailNotifier
{
    public void NotifyEmailMessage(string message)
    {
        Console.WriteLine(message);
    }
}
public class SendGridEmail : IEmailNotifier
{
    public void NotifyEmailMessage(string message)
    {
        Console.WriteLine(message);
    }
}
// Could ==> TwilioMessage , Smpt
//Internal ==> SendGrid,CompanySms
public interface INotitiferFactory
{
    public IEmailNotifier CreateEmail();
    public ISmsNotifier CreateSms();
}
public class CloudMessage : INotitiferFactory
{
    public IEmailNotifier CreateEmail()
     => new SmptEmail();

    public ISmsNotifier CreateSms()
     =>new TwilioSms();
}
public class InternalMessage : INotitiferFactory
{
    public IEmailNotifier CreateEmail()
     => new SendGridEmail();

    public ISmsNotifier CreateSms()
     => new CompanySms();
}
