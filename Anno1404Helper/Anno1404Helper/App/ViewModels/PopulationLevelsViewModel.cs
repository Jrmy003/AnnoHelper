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
    public event EventHandler Initialize;
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
        Initialize += OnInitialize;
        Initialize?.Invoke(this, EventArgs.Empty);
    }

    private async void OnInitialize(object sender, EventArgs e)
    {
        await _anno1404Service.LoadJson();
        PopulationLevels = new ObservableCollection<PopulationLevelModel>(_anno1404Service.PopulationLevelModels);
    }

    [RelayCommand]
    private async Task ComputeNeeds()
    {
        
        // // _anno1404Service.UpdateNeededProducts(PopulationLevelModels.ToList());
        // var dico = new Dictionary<int, ConsumptionModel>();
        // foreach (var PopulationLevelModel in _populationLevels)
        // {
        //     foreach (var consumption in PopulationLevelModel.Consumptions)
        //     {
        //         if (dico.TryGetValue(consumption.Product.Guid, out var value))
        //         {
        //             value.ConsumptionPerMinute += PopulationLevelModel.Count ?? 0 * consumption.Tpmin;
        //         }
        //         else
        //         {
        //             var newNeed = new ConsumptionModel
        //             {
        //                 Guid = consumption.Guid,
        //                 Product = consumption.Product,
        //                 Tpmin = consumption.Tpmin * PopulationLevelModel.Count ?? 0
        //             };
        //             dico.Add(consumption.Guid, newNeed);
        //         }
        //     }
        // }

        var consumptionViewModel = ServiceHelper.GetService<ConsumptionViewModel>();
        if (consumptionViewModel == null)
            throw new NullReferenceException(nameof(consumptionViewModel));
        // consumptionViewModel.
            
        await Shell.Current.Navigation.PushAsync(new ConsumptionPage(consumptionViewModel), true);
    }

    [RelayCommand]
    private async Task Back()
    {
        await Shell.Current.Navigation.PopAsync();
    }
}