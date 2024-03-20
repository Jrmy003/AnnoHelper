using Anno1404Helper.App.Helpers;
using Anno1404Helper.App.ViewModels;

namespace Anno1404Helper.App.Views;

public partial class PopulationLevelsPage : ContentPage
{
    public PopulationLevelsPage()
    {
        InitializeComponent();
        BindingContext = ServiceHelper.GetService<PopulationLevelsViewModel>();
    }
}