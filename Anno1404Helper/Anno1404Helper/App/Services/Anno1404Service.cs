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
    public async Task<bool> LoadJsonAsync()
    {
        await using var stream = await FileSystem.OpenAppPackageFileAsync("params_origin.json");
        using var reader = new StreamReader(stream);
        
        Anno1404Data = JsonConvert.DeserializeObject<Anno1404Data>(await reader.ReadToEndAsync());

        foreach (var product in Anno1404Data.Products)
        {
            product.Base64Icon = GetBase64Icon(product.IconPath);
        }

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
        
        PopulationLevelModels = Anno1404Data.PopulationLevels.ConvertAll(PopulationLevelFactory.ToModel);
        FactoryModels = Anno1404Data.Factories.ConvertAll(FactoryFactory.ToModel);
        
        return true;
    }

    private string GetBase64Icon(string iconPath)
    {
        return Anno1404Data.Icons.TryGetValue(iconPath, out var icon)
            ? icon.Substring(22)
            : null;
    }
    
    public async Task Save(Anno1404Data data)
    {
    // public List<string> Languages { get; set; }
    // public List<object> PopulationGroups { get; set; }
    // public List<PopulationLevel> PopulationLevels { get; set; }
    // public List<ProductFilter> ProductFilter { get; set; }
    // public List<Product> Products { get; set; }
    // public List<ResidenceBuilding> ResidenceBuildings { get; set; }
    // public List<Trader> Traders { get; set; }
    // public List<object> Workforce { get; set; }
        // using var db = GetDatabase();
        // var factories = db.GetCollection<Factory>();
        // var icons = db.GetCollection<Icons>();
        // var populationLevels = db.GetCollection<PopulationLevel>();
        // var products = db.GetCollection<Product>();
        // var languages = db.GetCollection<string>();
        //
        // await factories.InsertAsync(data.Factories);
        // await icons.InsertAsync(data.Icons);
        // await populationLevels.InsertAsync(data.PopulationLevels);
        // await products.InsertAsync(data.Products);
        // await languages.InsertAsync(data.Languages);
    }
    //
    // public async Task<List<PopulationLevelModel>> GetPopulationLevels()
    // {
    //     // using var db = GetDatabase();
    //     // var populationLevels = db.GetCollection<PopulationLevel>();
    //     //
    //     // var models = await populationLevels
    //     //     .Query()
    //     //     .Include(x=>x.Needs)
    //     //     .Select(x=> new PopulationLevelModel()
    //     //     {
    //     //         Name = x.LocaText.French,
    //     //         IconPath = x.IconPath,
    //     //         Consumptions = 
    //     //         
    //     //     }).
    //     //    
    //     //
    //     // var toto = new Icons().
    //     // // have to find a way to get the right icon
    //     // // var icons = db.GetCollection<Icons>();
    //     // // foreach (var model in models)
    //     // // {
    //     // //     model.IconPath = await icons.FindOneAsync($"{model.IconPath}");
    //     // // }
    //     // return null;
    // }
    //
    // public void UpdateNeededProducts(List<PopulationLevel> populationLevels)
    // {
    //     // PopulationLevels = populationLevels;
    //     NeededProducts = new ();
    //     // foreach (var populationLevel in populationLevels)
    //     // {
    //     //     foreach (var need in populationLevel.Needs)
    //     //     {
    //     //         var amout = populationLevel.Count ?? 0;
    //     //         var tpmin = need.Tpmin;
    //     //         if (NeededProducts.ContainsKey(need.Guid))
    //     //         {
    //     //             NeededProducts.Add(need.Guid, new ConsumptionModel
    //     //             {
    //     //                 Amount = amout;
    //     //             });
    //     //         }
    //     //         else
    //     //         {
    //     //             NeededProducts[need.Guid].Amount += amout;
    //     //         }
    //     //     }
    //     // }
    //
    //
    // }
}