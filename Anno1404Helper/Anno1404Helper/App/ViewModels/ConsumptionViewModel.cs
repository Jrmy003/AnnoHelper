using System.Collections.ObjectModel;
using Anno1404Helper.App.Helpers;
using Anno1404Helper.App.Models;
using Anno1404Helper.App.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.ViewModels;

public partial class ConsumptionViewModel : ObservableObject
{
    private ObservableCollection<NeedModel> _needs;
    private NeedModel _selectedNeed;
    private ObservableCollection<PopulationLevelModel> _populationLevels;

    public ObservableCollection<NeedModel> Needs
    {
        get => _needs;
        set => SetProperty(ref _needs, value);
    }

    public NeedModel SelectedNeed
    {
        get => _selectedNeed;
        set
        {
            DisplayConsumptionDetailPage(value);
            // selection not need, juste handle selection changed in vm to open ConsumptionDetailsViewModel
            SetProperty(ref _selectedNeed, null);
        }
    }

    public ObservableCollection<PopulationLevelModel> PopulationLevels
    {
        get => _populationLevels;
        set
        {
            SetProperty(ref _populationLevels, value);
            ComputeNeeds();
        }
    }

    private void ComputeNeeds()
    {
        if (_populationLevels == null) return;
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
                        ConsumptionPerMinute = (populationLevelModel.Count ?? 0 / populationLevelModel.FullHouse) *
                                               need.ConsumptionPerMinute,
                        Factory = need.Factory
                    };
                    dico.Add(need.Product.Id, newNeed);
                }
            }
        }

        Needs = new(dico.Values);
    }

    private async void DisplayConsumptionDetailPage(NeedModel need)
    {
        if (need == null) return;

        // gets the page
        var page = ServiceHelper.GetService<ConsumptionDetailsPage>();
        if (page == null) return;

        // gets its viewmodel already associated via IOC
        var consumptionViewModel = ServiceHelper.GetService<ConsumptionDetailsViewModel>();
        if (consumptionViewModel == null)
            return;
        //
        // var consumptionViewModel = new ConsumptionDetailsViewModel
        // {
        //     // update the view model data
        //     Factory = need.Factory
        // };

        //displays the view 
        // await Shell.Current.Navigation.PushAsync(new ConsumptionDetailsPage(consumptionViewModel), true);
        await Shell.Current.Navigation.PushAsync(page, true);
    }
}