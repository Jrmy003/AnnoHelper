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

    private async void Initialize()
    {
        await _anno1404Service.LoadJsonAsync();
        PopulationLevels = new ObservableCollection<PopulationLevelModel>(_anno1404Service.PopulationLevelModels);
    }

    [RelayCommand]
    private async Task ComputeNeeds()
    {
        
        // // _anno1404Service.UpdateNeededProducts(PopulationLevelModels.ToList());
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

        var page = new ConsumptionPage();
        var consumptionViewModel = ServiceHelper.GetService<ConsumptionViewModel>();
        if (consumptionViewModel == null)
            throw new NullReferenceException(nameof(consumptionViewModel));
        consumptionViewModel.Needs = new(dico.Values);
        page.BindingContext = consumptionViewModel;
        await Shell.Current.Navigation.PushAsync(page, true);
    }

    [RelayCommand]
    private async Task Back()
    {
        await Shell.Current.Navigation.PopAsync();
    }
}