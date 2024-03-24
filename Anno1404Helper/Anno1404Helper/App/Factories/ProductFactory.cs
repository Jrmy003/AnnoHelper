using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;

namespace Anno1404Helper.App.Factories;

public static class ProductFactory
{
    public static ProductModel ToModel(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        
        var imageBytes = Convert.FromBase64String(product.Base64Icon);
        MemoryStream imageDecodeStream = new(imageBytes);
        return new ProductModel
        {
            Id = product.Guid,
            Name = product.LocaText.English,
            Icon = ImageSource.FromStream(() => imageDecodeStream)
        };
    }
}