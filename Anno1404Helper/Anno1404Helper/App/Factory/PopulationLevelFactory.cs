using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;

namespace Anno1404Helper.App.Factory;

public static class PopulationLevelFactory
{
    public static PopulationLevelModel ToModel(PopulationLevel populationLevel)
    {
        return new PopulationLevelModel
        {
            Id = populationLevel.Guid,
            Name = populationLevel.LocaText.English,
            IconData = populationLevel.Base64Icon,
            Consumptions = populationLevel.Needs.ConvertAll(NeedFactory.ToModel)
        };
    }
}