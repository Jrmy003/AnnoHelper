using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class FactoryModel : ObservableObject
{
    private int _id;
    private List<InputModel> _inputs;
    private string _name;
    private List<OutputModel> _outputs;
    private decimal _productionPerMinute;
    private int _amoutNeeded;
    private ImageSource _icon;

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public List<InputModel> Inputs
    {
        get => _inputs;
        set
        {
            if (SetProperty(ref _inputs, value))
                OnPropertyChanged(nameof(HasInputs));
        }
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public List<OutputModel> Outputs
    {
        get => _outputs;
        set => SetProperty(ref _outputs, value);
    }

    public decimal ProductionPerMinute
    {
        get => _productionPerMinute;
        set => SetProperty(ref _productionPerMinute, value);
    }

    public ImageSource Icon
    {
        get => _icon;
        set => SetProperty(ref _icon, value);
    }

    /// <summary>
    /// Indicates if this factory need inputs.
    /// </summary>
    public bool HasInputs => (_inputs?.Count ?? 0) > 0;

    public int AmoutNeeded
    {
        get => _amoutNeeded;
        set => SetProperty(ref _amoutNeeded, value);
    }

    public override bool Equals(object obj)
    {
        var factory = obj as FactoryModel;
        if (factory == null)
            return false;
        return Equals(factory);
    }

    protected bool Equals(FactoryModel other)
    {
        return _id == other._id;
    }

    public override int GetHashCode()
    {
        return _id;
    }
}