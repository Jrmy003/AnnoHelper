using Anno1404Helper.App.Factories;
using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;
using Newtonsoft.Json;

namespace Anno1404Helper.App.Services;

public class Anno1404Service
{
    public List<PopulationLevelModel> PopulationLevelModels { get; set; }
    public List<FactoryModel> FactoryModels { get; set; }
    public Anno1404Data Anno1404Data { get; set; }
    
    /// <summary>
    /// Loads json and convert json structure to internal models structure
    /// </summary>
    /// <returns></returns>
    public async Task LoadJsonAsync()
    {
        await using var stream = await FileSystem.OpenAppPackageFileAsync("params_origin.json");
        using var reader = new StreamReader(stream);
        
        Anno1404Data = JsonConvert.DeserializeObject<Anno1404Data>(await reader.ReadToEndAsync());

        //loads products icons
        foreach (var product in Anno1404Data.Products)
        {
            product.Base64Icon = GetBase64Icon(product.IconPath);
        }

        // loads factories icons, and associate products to inputs and outputs
        foreach (var factory in Anno1404Data.Factories)
        {
            factory.Base64Icon = GetBase64Icon(factory.IconPath);
            foreach (var input in factory.Inputs)
            {
                input.ProductObject = Anno1404Data.Products.FirstOrDefault(x => x.Guid == input.Product);
                input.Factory = Anno1404Data.Factories.FirstOrDefault(x => x.Outputs[0]?.Product == input.Product);
            }
            
            foreach (var output in factory.Outputs)
            {
                output.ProductObject = Anno1404Data.Products.FirstOrDefault(x => x.Guid == output.Product);
            }
        }
        
        // loads icons to population levels, and associate factory to need through product id
        foreach (var populationLevel in Anno1404Data.PopulationLevels)
        {
            populationLevel.Base64Icon = GetBase64Icon(populationLevel.IconPath);
            foreach (var need in populationLevel.Needs)
            {
                need.ProductObject = Anno1404Data.Products.FirstOrDefault(x => x.Guid == need.Guid);
                foreach (var factory in Anno1404Data.Factories)
                {
                    if (factory.Outputs != null && factory.Outputs.Count == 1 &&
                        factory.Outputs[0].Product == need.ProductObject?.Guid)
                    {
                        need.Factory = factory;
                        break;
                    }
                }
            }

        }
        
        // saves data in service while app dont not have database
        PopulationLevelModels = Anno1404Data.PopulationLevels.ConvertAll(PopulationLevelFactory.ToModel);
        FactoryModels = Anno1404Data.Factories.ConvertAll(FactoryFactory.ToModel);
    }

    /// <summary>
    /// Gets the base 64 icon data from icon path.
    /// </summary>
    /// <param name="iconPath">the icon's path</param>
    /// <returns></returns>
    private string GetBase64Icon(string iconPath)
    {
        return Anno1404Data.Icons.TryGetValue(iconPath, out var icon)
            ? icon.Substring(22)
            : null;
    }
}