using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class  OutputModel : ObservableObject
{
    private decimal _amount;
    private int _productId;
    private ProductModel _product;

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

    public ProductModel Product
    {
        get => _product;
        set => SetProperty(ref _product, value);
    }
}