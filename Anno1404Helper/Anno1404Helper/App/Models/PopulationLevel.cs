using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class PopulationLevel : ObservableObject
{
    private int _fullHouse;
    private int _guid;
    private string _iconPath;
    private LocaText _locaText;
    private string _name;
    private List<Need> _needs;
    private int _residence;
    private int? _residenceUpgradeAmountMaxPercent;
    private int? _count;
    private Icon _icon;

    public int FullHouse
    {
        get => _fullHouse;
        set => SetProperty(ref _fullHouse, value);
    }

    public int Guid
    {
        get => _guid;
        set => SetProperty(ref _guid, value);
    }

    public string IconPath
    {
        get => _iconPath;
        set => SetProperty(ref _iconPath, value);
    }

    public LocaText LocaText
    {
        get => _locaText;
        set => SetProperty(ref _locaText, value);
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public List<Need> Needs
    {
        get => _needs;
        set => SetProperty(ref _needs, value);
    }

    public int Residence
    {
        get => _residence;
        set => SetProperty(ref _residence, value);
    }

    public int? ResidenceUpgradeAmountMaxPercent
    {
        get => _residenceUpgradeAmountMaxPercent;
        set => SetProperty(ref _residenceUpgradeAmountMaxPercent, value);
    }

    public int? Count
    {
        get => _count;
        set => SetProperty(ref _count, value);
    }

    public Icon Icon
    {
        get => _icon;
        set => SetProperty(ref _icon, value);
    }
}