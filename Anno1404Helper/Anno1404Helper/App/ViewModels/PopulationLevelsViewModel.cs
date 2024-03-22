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
    private PopulationLevelModel _selectedItem;

    public ObservableCollection<PopulationLevelModel> PopulationLevels
    {
        get => _populationLevels;
        set => SetProperty(ref _populationLevels, value);
    }

    public PopulationLevelModel SelectedItem
    {
        get => _selectedItem;
        set => SetProperty(ref _selectedItem, value);
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
        PopulationLevels = new ObservableCollection<PopulationLevelModel>(_anno1404Service.PopulationLevelModels);
    }

    [RelayCommand]
    private async Task ComputeNeeds()
    {
        
        // cumulates needs of every population level in a flat list using dictionary
        var dico = new Dictionary<int, NeedModel>();
        foreach (var populationLevelModel in _populationLevels)
        {
            foreach (var need in populationLevelModel.Need)
            {
                if (dico.TryGetValue(need.Product.Id, out var value))
                {
                    value.ConsumptionPerMinute += (populationLevelModel.Count ??
                                                  0 / populationLevelModel.FullHouse) * need.ConsumptionPerMinute;
                }
                else
                {
                    var newNeed = new NeedModel
                    {
                        Product = need.Product,
                        ConsumptionPerMinute = (populationLevelModel.Count ?? 0 / populationLevelModel.FullHouse) * need.ConsumptionPerMinute,
                        Factory = need.Factory
                    };
                    dico.Add(need.Product.Id, newNeed);
                }
            }
        }

        // instantiates view and associate it to its viewmodel
        // TODO : Have to define in which order these instructions have to be called to optimize loading of next screen
        var page = new ConsumptionPage();
        var consumptionViewModel = ServiceHelper.GetService<ConsumptionViewModel>();
        if (consumptionViewModel == null)
            throw new NullReferenceException(nameof(consumptionViewModel));
        consumptionViewModel.Needs = new(dico.Values);
        page.BindingContext = consumptionViewModel;
        
        //displays the view 
        await Shell.Current.Navigation.PushAsync(page, true);
    }

    // [RelayCommand]
    // private async Task Back()
    // {
    //     await Shell.Current.Navigation.PopAsync();
    // }
}