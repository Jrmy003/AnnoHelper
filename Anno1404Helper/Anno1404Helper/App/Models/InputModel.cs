using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class InputModel : ObservableObject
{
    private decimal _amount;
    private int _productId;
    private FactoryModel _childFactory;
    private FactoryModel _parentFactory;

    public decimal Amount
    {
        get => _amount;
        set => SetProperty(ref _amount, value);
    }

    public int ProductId
    {
        get => _productId;
        set => SetProperty(ref _productId, value);
    }

    public FactoryModel ChildFactory
    {
        get => _childFactory;
        set => SetProperty(ref _childFactory, value);
    }
    
    public FactoryModel ParentFactoryModel
    {
        get => _parentFactory;
        set => SetProperty(ref _parentFactory, value);
    }

    public decimal NeededFactories => Math.Ceiling(_parentFactory.ProductionPerMinute * Amount / (_childFactory.ProductionPerMinute * _childFactory.Outputs[0]?.Amount ?? 1));
}