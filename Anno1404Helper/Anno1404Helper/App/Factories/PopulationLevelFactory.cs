using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;

namespace Anno1404Helper.App.Factories;

public static class PopulationLevelFactory
{
    public static PopulationLevelModel ToModel(PopulationLevel populationLevel)
    {
        if (populationLevel == null) throw new ArgumentNullException(nameof(populationLevel));
        
        var imageBytes = Convert.FromBase64String(populationLevel.Base64Icon);
        MemoryStream imageDecodeStream = new(imageBytes);
        
        return new PopulationLevelModel
        {
            Id = populationLevel.Guid,
            Name = populationLevel.LocaText.English,
            IconData = populationLevel.Base64Icon,
            Icon = ImageSource.FromStream(() => imageDecodeStream),
            Order = populationLevel.Order,
            Need = populationLevel.Needs.ConvertAll(NeedFactory.ToModel),
            FullHouse = populationLevel.FullHouse,
            ResidenceUpgradeAmountMaxPercent = populationLevel.ResidenceUpgradeAmountMaxPercent
        };
    }
}