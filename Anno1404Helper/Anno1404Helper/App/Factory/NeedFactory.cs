using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;

namespace Anno1404Helper.App.Factory;

public class NeedFactory
{
    public static NeedModel ToModel(Need need)
    {
        return new NeedModel
        {
            Product = ProductFactory.ToModel(need.Product),
            ConsumptionPerMinute = need.Tpmin,
        };
    }
}