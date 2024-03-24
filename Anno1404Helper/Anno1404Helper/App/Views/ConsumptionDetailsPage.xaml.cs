using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anno1404Helper.App.Helpers;
using Anno1404Helper.App.ViewModels;

namespace Anno1404Helper.App.Views;

public partial class ConsumptionDetailsPage : ContentPage
{
    public ConsumptionDetailsPage()
    {
        InitializeComponent();
        BindingContext = ServiceHelper.GetService<ConsumptionDetailsViewModel>();
    }
}