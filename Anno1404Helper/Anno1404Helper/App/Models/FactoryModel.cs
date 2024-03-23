using Android.Content.Res;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class FactoryModel : ObservableObject
{
    private int _id;
    private string _iconData;
    private List<InputModel> _inputs;
    private string _name;
    private List<OutputModel> _outputs;
    private decimal _productionPerMinute;

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
        get
        {
            var imageBytes = Convert.FromBase64String(IconData);
            MemoryStream imageDecodeStream = new(imageBytes);
            return ImageSource.FromStream(() => imageDecodeStream);
        }
    }

    /// <summary>
    /// Indicates if this factory need inputs.
    /// </summary>
    public bool HasInputs => (_inputs?.Count ?? 0) > 0;
    
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