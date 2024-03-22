using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;

namespace Anno1404Helper.App.Factories;

public static class NeedFactory
{
    public static NeedModel ToModel(Need need)
    {
        if (need == null) throw new ArgumentNullException(nameof(need));
        
        return new NeedModel
        {
            Product = ProductFactory.ToModel(need.ProductObject),
            ConsumptionPerMinute = need.Tpmin,
            Factory = FactoryFactory.ToModel(need.Factory)
        };
    }
}