using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.Models;

public class LocaText : ObservableObject
{
    private string _czech;
    private string _english;
    private string _french;
    private string _german;
    private string _italian;
    private string _polish;
    private string _russian;
    private string _spanish;
    private string _brazilian;
    private string _chinese;
    private string _japanese;
    private string _korean;
    private string _portuguese;
    private string _taiwanese;

    public string Czech
    {
        get => _czech;
        set => SetProperty(ref _czech, value);
    }

    public string English
    {
        get => _english;
        set => SetProperty(ref _english, value);
    }

    public string French
    {
        get => _french;
        set => SetProperty(ref _french, value);
    }

    public string German
    {
        get => _german;
        set => SetProperty(ref _german, value);
    }

    public string Italian
    {
        get => _italian;
        set => SetProperty(ref _italian, value);
    }

    public string Polish
    {
        get => _polish;
        set => SetProperty(ref _polish, value);
    }

    public string Russian
    {
        get => _russian;
        set => SetProperty(ref _russian, value);
    }

    public string Spanish
    {
        get => _spanish;
        set => SetProperty(ref _spanish, value);
    }

    public string Brazilian
    {
        get => _brazilian;
        set => SetProperty(ref _brazilian, value);
    }

    public string Chinese
    {
        get => _chinese;
        set => SetProperty(ref _chinese, value);
    }

    public string Japanese
    {
        get => _japanese;
        set => SetProperty(ref _japanese, value);
    }

    public string Korean
    {
        get => _korean;
        set => SetProperty(ref _korean, value);
    }

    public string Portuguese
    {
        get => _portuguese;
        set => SetProperty(ref _portuguese, value);
    }

    public string Taiwanese
    {
        get => _taiwanese;
        set => SetProperty(ref _taiwanese, value);
    }
}