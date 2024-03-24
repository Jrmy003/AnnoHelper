using Anno1404Helper.App.ViewModels;

namespace Anno1404Helper.App.Views;

public partial class ConsumptionDetailsPage : ContentPage
{
    public ConsumptionDetailsPage(ConsumptionDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}