using Anno1404Helper.App.Helpers;
using Anno1404Helper.App.Services;
using Anno1404Helper.App.ViewModels;
using Microsoft.Extensions.Logging;

namespace Anno1404Helper;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App.App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterViewModels()
            .RegisterServices();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();
        ServiceHelper.Initialize(app.Services);
        return app;
    }
    
    private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<PopulationLevelsViewModel>();
        mauiAppBuilder.Services.AddSingleton<ConsumptionViewModel>();
        mauiAppBuilder.Services.AddSingleton<ConsumptionDetailsViewModel>();

        return mauiAppBuilder;
    }
    
    private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<Anno1404Service>();

        return mauiAppBuilder;
    }
}