using System.Collections.ObjectModel;
using Anno1404Helper.App.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Anno1404Helper.App.ViewModels;

public class ConsumptionDetailsViewModel : ObservableObject
{
    private FactoryModel _factory;
    private ObservableCollection<InputModel> _nodes;

    public FactoryModel Factory
    {
        get => _factory;
        set
        {
            if (SetProperty(ref _factory, value))
                UpdateProductionChains();
        }
    }

    public ObservableCollection<InputModel> Nodes
    {
        get => _nodes;
        set => SetProperty(ref _nodes, value);
    }

    private void UpdateProductionChains()
    {
        if(_factory == null) return;
        
        Nodes = new ObservableCollection<InputModel>();
        // ExploreGraph(_factory, new HashSet<int>());
        Dfs(_factory);
    }

    /// <summary>
    /// Depth First Search recursive way to find production chains.
    /// </summary>
    /// <param name="factory">current factory</param>
    /// <param name="visited">already visited edge set</param>
    private void DfsUtil(FactoryModel factory, HashSet<int> visited)
    {
        // Marquer le sommet actuel comme visité
        visited.Add(factory.Id);

        // Parcourir tous les voisins non visités du sommet actuel
        foreach (InputModel neighbor in factory.Inputs)
        {
            if (!visited.Contains(neighbor.Factory.Id))
            {
                Nodes.Add(neighbor);
                DfsUtil(neighbor.Factory, visited);
            }
        }
    }

    /// <summary>
    /// Start Depth First Search recursive way.
    /// </summary>
    /// <param name="start">factory from where to start production chains analysis</param>
    private void Dfs(FactoryModel start)
    {
        // HashSet pour marquer les sommets visités
        HashSet<int> visited = new HashSet<int>();

        // Appeler la méthode utilitaire récursive pour effectuer le parcours en profondeur
        DfsUtil(start, visited);
    }
}