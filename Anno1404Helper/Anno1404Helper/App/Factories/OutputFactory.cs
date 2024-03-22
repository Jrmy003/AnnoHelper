using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;

namespace Anno1404Helper.App.Factories;

public static class OutputFactory
{
    public static OutputModel ToModel(Output input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        
        return new OutputModel
        {
            Amount = input.Amount,
            ProductId = input.Product,
            Product = ProductFactory.ToModel(input.ProductObject)
        };
    }
}