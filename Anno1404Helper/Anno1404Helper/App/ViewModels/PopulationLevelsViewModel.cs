using System.Collections.ObjectModel;
using Anno1404Helper.App.Helpers;
using Anno1404Helper.App.Models;
using Anno1404Helper.App.Services;
using Anno1404Helper.App.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Anno1404Helper.App.ViewModels;

public partial class PopulationLevelsViewModel : ObservableObject
{
    private ObservableCollection<PopulationLevelModel> _populationLevels;
    private PopulationLevelModel _selectedPopulationLevel;

    public ObservableCollection<PopulationLevelModel> PopulationLevels
    {
        get => _populationLevels;
        set => SetProperty(ref _populationLevels, value);
    }

    public PopulationLevelModel SelectedPopulationLevel
    {
        get => _selectedPopulationLevel;
        set => SetProperty(ref _selectedPopulationLevel, value);
    }

    private readonly Anno1404Service _anno1404Service = ServiceHelper.GetService<Anno1404Service>();

    public PopulationLevelsViewModel()
    {
        Initialize();
    }

    /// <summary>
    /// Initialize data to display.
    /// </summary>
    private async void Initialize()
    {
        // load json and convert everything to models
        await _anno1404Service.LoadJsonAsync();
        // gets population levels models to display
        PopulationLevels = new ObservableCollection<PopulationLevelModel>(_anno1404Service
            .PopulationLevelModels);
    }

    [RelayCommand]
    private async Task ComputeNeeds()
    {
        // gets the page
        var page = ServiceHelper.GetService<ConsumptionPage>();
        if (page == null) return;
        
        // gets its viewmodel already associated via IOC
        var consumptionViewModel = ServiceHelper.GetService<ConsumptionViewModel>();
        if (consumptionViewModel == null) return;
        
        // update the view model data
        consumptionViewModel.PopulationLevels = PopulationLevels;
        
        //displays the view 
        await Shell.Current.Navigation.PushAsync(page, true);
    }
}