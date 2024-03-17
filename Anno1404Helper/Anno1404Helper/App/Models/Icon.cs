using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class Icon : ObservableObject
{
    private string _guid;
    private string _data;

    public string Guid
    {
        get => _guid;
        set => SetProperty(ref _guid, value);
    }

    public string Data
    {
        get => _data;
        set
        {
            if (SetProperty(ref _data, value)) OnPropertyChanged(nameof(Source));
        }
    }

    public ImageSource Source
    {
        get
        {
            var imageBytes = Convert.FromBase64String(Data);
            MemoryStream imageDecodeStream = new(imageBytes);
            return ImageSource.FromStream(() => imageDecodeStream);
        }
    }
}