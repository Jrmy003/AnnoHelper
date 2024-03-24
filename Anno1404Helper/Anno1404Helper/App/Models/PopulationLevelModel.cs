using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class PopulationLevelModel : ObservableObject
{
    private int _id;
    private string _name;
    private decimal? _count;
    private string _iconData;
    private List<NeedModel> _need;
    private decimal _fullHouse;
    private int? _residenceUpgradeAmountMaxPercent;
    private int _order;
    private ImageSource _icon;

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }
    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public decimal? Count
    {
        get => _count;
        set => SetProperty(ref _count, value);
    }

    public List<NeedModel> Need
    {
        get => _need;
        set => SetProperty(ref _need, value);
    }
    
    public string IconData
    {
        get => _iconData;
        set
        {
            if (SetProperty(ref _iconData, value)) OnPropertyChanged(nameof(Icon));
        }
    }

    public ImageSource Icon
    {
        get => _icon;
        set => SetProperty(ref _icon, value);
    }

    public decimal FullHouse
    {
        get => _fullHouse;
        set => SetProperty(ref _fullHouse, value);
    }

    public int? ResidenceUpgradeAmountMaxPercent
    {
        get => _residenceUpgradeAmountMaxPercent;
        set => SetProperty(ref _residenceUpgradeAmountMaxPercent, value);
    }

    public int Order
    {
        get => _order;
        set => SetProperty(ref _order, value);
    }

    public ReturnType ReturnType => _id == 51910 ? ReturnType.Done : ReturnType.Next;
}