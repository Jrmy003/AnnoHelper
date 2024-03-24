using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;

namespace Anno1404Helper.App.Factories;

public static class InputFactory
{
    public static InputModel ToModel(Input input, FactoryModel parentFactory)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        
        return new InputModel
        {
            Amount = input.Amount,
            ProductId = input.Product,
            ChildFactory = FactoryFactory.ToModel(input.Factory),
            ParentFactoryModel = parentFactory
        };
    }
}