using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class PopulationLevelModel : ObservableObject
{
    private int _id;
    private string _name;
    private string _count;
    private string _iconData;
    private List<NeedModel> _consumptions;

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

    public string Count
    {
        get => _count;
        set => SetProperty(ref _count, value);
    }

    public List<NeedModel> Consumptions
    {
        get => _consumptions;
        set => SetProperty(ref _consumptions, value);
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