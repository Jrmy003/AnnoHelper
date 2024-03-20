using System.Collections.ObjectModel;
using Anno1404Helper.App.Helpers;
using Anno1404Helper.App.Json;
using Anno1404Helper.App.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Anno1404Helper.App.ViewModels;

public partial class ConsumptionViewModel : ObservableRecipient
{
    private ObservableCollection<Need> _needs;
    private Need _selectedNeed;
    
    public ObservableCollection<Need> Needs
    {
        get => _needs;
        set => SetProperty(ref _needs, value);
    }
    
    public Need SelectedNeed
    {
        get => _selectedNeed;
        set => SetProperty(ref _selectedNeed, value);
    }
    
    private readonly Anno1404Service _anno1404Service;
    
    public ConsumptionViewModel()
    {
        _anno1404Service = ServiceHelper.GetService<Anno1404Service>();
        // Needs = new(xxxxxxxx);
    }
    
    [RelayCommand]
    private async Task Back()
    {
        await Shell.Current.Navigation.PopAsync(true);
    }
}