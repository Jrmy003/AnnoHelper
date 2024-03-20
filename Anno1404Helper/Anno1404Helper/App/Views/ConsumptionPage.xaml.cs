using Android.Content;
using Anno1404Helper.App.Helpers;
using Anno1404Helper.App.ViewModels;

namespace Anno1404Helper.App.Views;

public partial class ConsumptionPage : ContentPage
{
    public ConsumptionPage(ConsumptionViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}