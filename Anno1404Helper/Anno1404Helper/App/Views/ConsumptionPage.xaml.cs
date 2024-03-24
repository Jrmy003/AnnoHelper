using Anno1404Helper.App.ViewModels;

namespace Anno1404Helper.App.Views;

public partial class ConsumptionPage : ContentPage
{
    public ConsumptionPage(ConsumptionViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }


    private void ConsumptionPage_OnDisappearing(object sender, EventArgs e)
    {
        // disable selection on disapearing event
        LvNeeds.SelectedItem = null;
    }
}