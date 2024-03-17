using System.Collections.ObjectModel;
using Anno1404Helper.App.Models;
using Anno1404Helper.App.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;

namespace Anno1404Helper.App.ViewModels;

public partial class PopulationLevelsViewModel : ObservableObject
{
    private ObservableCollection<PopulationLevel> _populationLevels;
    private PopulationLevel _selectedItem;

    public ObservableCollection<PopulationLevel> PopulationLevels
    {
        get => _populationLevels;
        set => SetProperty(ref _populationLevels, value);
    }

    public PopulationLevel SelectedItem
    {
        get => _selectedItem;
        set => SetProperty(ref _selectedItem, value);
    }

    public PopulationLevelsViewModel()
    {
        
        using var stream = FileSystem.OpenAppPackageFileAsync("params.json").Result;
        using var reader = new StreamReader(stream);
        
        Params root = JsonConvert.DeserializeObject<Params>(reader.ReadToEnd());
        foreach (var populationLevel in root.PopulationLevels)
        {
            populationLevel.Icon = root.Icons.FirstOrDefault(x=>x.Guid ==  populationLevel.IconPath);
        }
        PopulationLevels = new ObservableCollection<PopulationLevel>(root.PopulationLevels);
    }

    [RelayCommand]
    private async Task ComputeNeeds()
    {
        var needs = new List<Need>();
        foreach (var populationLevel in PopulationLevels)
        {
            needs.AddRange(populationLevel.Needs);
        }

        await Shell.Current.GoToAsync("///ConsumptionPage");
        // var toto = needs.GroupBy(x=>x.Guid).Sum((x)=>x.)
        // Dispatcher.GetForCurrentThread().
    }
}