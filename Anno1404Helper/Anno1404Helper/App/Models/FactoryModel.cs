using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class FactoryModel : ObservableObject
{
    private int _id;
    private string _iconData;
    private List<InputModel> _inputs;
    private string _name;
    private List<OutputModel> _outputs;
    private decimal _tpmin;

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public List<InputModel> Inputs
    {
        get => _inputs;
        set => SetProperty(ref _inputs, value);
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
        get => _tpmin;
        set => SetProperty(ref _tpmin, value);
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
}