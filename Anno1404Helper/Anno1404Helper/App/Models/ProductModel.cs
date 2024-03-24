using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class ProductModel : ObservableObject
{
    private int _id;
    private string _iconData;
    private string _name;
    private ImageSource _icon;

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public string IconData
    {
        get => _iconData;
        set => SetProperty(ref _iconData, value);
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }
    
    public ImageSource Icon
    {
        get => _icon;
        set => SetProperty(ref _icon, value);
    }
}