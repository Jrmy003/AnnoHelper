using Anno1404Helper.App.Models;
using Anno1404Helper.App.ViewModels;

namespace Anno1404Helper.App.Views;

public partial class ConsumptionPage : ContentPage
{
    public ConsumptionPage()
    {
        InitializeComponent();
    }

    private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedItem = e.SelectedItem as NeedModel;
        if (selectedItem == null) return;
        var vm = BindingContext as ConsumptionViewModel;
        if (vm == null) return;

        // display ConsumptionDetailPage
        await vm.DisplayConsumptionDetailPage(selectedItem);

        // raz selected item
        LvNeeds.SelectedItem = null;
    }
}