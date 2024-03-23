using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class NeedModel : ObservableObject
{
    private ProductModel _product;
    private decimal _consumptionPerMinute;
    private FactoryModel _factory;

    public ProductModel Product
    {
        get => _product;
        set => SetProperty(ref _product, value);
    }

    public decimal ConsumptionPerMinute
    {
        get => _consumptionPerMinute;
        set => SetProperty(ref _consumptionPerMinute, value);
    }

    public FactoryModel Factory
    {
        get => _factory;
        set => SetProperty(ref _factory, value);
    }

    public decimal FactoryPercentUsage => FactoryDecimalUsage * 100;
    public decimal FactoryDecimalUsage => ConsumptionPerMinute == 0
        ? 0
        : (Factory.ProductionPerMinute - ((NbFactoriesNeeded * Factory.ProductionPerMinute) - ConsumptionPerMinute))
          / Factory.ProductionPerMinute;
    public decimal NbFactoriesNeeded => Math.Ceiling(ConsumptionPerMinute / Factory.ProductionPerMinute);
}