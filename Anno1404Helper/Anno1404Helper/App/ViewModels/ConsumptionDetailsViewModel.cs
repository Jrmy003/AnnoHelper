using System.Collections.ObjectModel;
using Anno1404Helper.App.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.ViewModels;

public class ConsumptionDetailsViewModel : ObservableObject
{
    public FactoryModel CurrentFactory { get; set; }

    public ObservableCollection<FactoryModel> Factories
    {
        get
        {
            if (CurrentFactory == null) return null;
            // FactoryModel parent;
            // HashSet<int> visited = new HashSet<int>();
            // do
            // {
            //     var leaf = parent.Inputs
            //         .Select(x => x.Factory)
            //         .FirstOrDefault(x => !visited.Contains(x.Id));
            //     visited.Add(leaf.Id)
            // } while (parent.Inputs?.Count != 0);

            return null;
        }
    }

    public ConsumptionDetailsViewModel()
    {
    }
}