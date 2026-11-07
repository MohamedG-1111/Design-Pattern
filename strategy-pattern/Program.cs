using System.ComponentModel.DataAnnotations;

namespace strategy_pattern;

public class ShippingServiceV1
{
    public decimal CalculateShipping(string shippingType)
    {
        if (shippingType == "Standard")
        {
            return 30;
        }
        else if (shippingType == "Express")
        {
            return 60;
        }
        else if (shippingType == "Free")
        {
            return 0;
        }

        throw new Exception("Invalid shipping type");
    }
}
// problem every time we want to add a new shipping type, we have to modify the ShippingService class.
// This violates the Open/Closed Principle,
// which states that classes should be open for extension but closed for modification.

public interface IShippingStrategy
{
    decimal CalculateShipping();
}
public class StandardShipping : IShippingStrategy
{
    public decimal CalculateShipping()
    {
        return 30;
    }
}

public class ExpressShipping : IShippingStrategy
{
    public decimal CalculateShipping()
    {
        return 60;
    }
}

public class FreeShipping : IShippingStrategy
{
    public decimal CalculateShipping()
    {
        return 0;
    }
}

public class ShippingServiceV2
{
    private readonly IShippingStrategy _shippingStrategy;

    public ShippingServiceV2(IShippingStrategy shippingStrategy)
    {
        _shippingStrategy= shippingStrategy;
    }
    public decimal CalculateShipping()
    {
        return _shippingStrategy.CalculateShipping();
    }
   

}
internal class Program
    {
        static void Main(string[] args)
        {
          var standardShipping = new ShippingServiceV2(new StandardShipping());
          Console.WriteLine($"Standard Shipping Cost: {standardShipping.CalculateShipping()}");
    }
    }

