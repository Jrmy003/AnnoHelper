using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;

namespace Anno1404Helper.App.Factory;

public static class ProductFactory
{
    public static ProductModel ToModel(Product product)
    {
        return new ProductModel
        {
            Id = product.Guid,
            Name = product.LocaText.English,
            IconData = product.Base64Icon
        };
    }
}