using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class InputModel : ObservableObject
{
    private decimal _amount;
    private int _productId;
    private ProductModel _product;
    private FactoryModel _factory;

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

    public FactoryModel Factory
    {
        get => _factory;
        set => SetProperty(ref _factory, value);
    }
}