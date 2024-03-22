using Anno1404Helper.App.Json;
using Anno1404Helper.App.Models;

namespace Anno1404Helper.App.Factories;

public static class FactoryFactory
{
    public static FactoryModel ToModel(Factory factory)
    {
        if (factory == null) throw new ArgumentNullException(nameof(factory));

        return new FactoryModel
        {
            Id = factory.Guid,
            Name = factory.LocaText.English,
            ProductionPerMinute = factory.Tpmin * factory.Outputs[0]?.Amount ?? 1,
            IconData = factory.Base64Icon,
            Inputs = factory.Inputs.ConvertAll(InputFactory.ToModel),
            Outputs = factory.Outputs.ConvertAll(OutputFactory.ToModel)
        };
    }
}