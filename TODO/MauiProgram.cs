using Microsoft.Extensions.Logging;
using TODO.Services; // Add this

namespace TODO
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("AnonymousPro-Regular.ttf", "AnonymousPro");
                });

            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<SignUpPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}


// using Microsoft.Extensions.Logging;

// namespace TODO
// {
//     public static class MauiProgram
//     {
//         public static MauiApp CreateMauiApp()
//         {
//             var builder = MauiApp.CreateBuilder();
//             builder
//                 .UseMauiApp<App>()
//                 .ConfigureFonts(fonts =>
//                 {
//                     fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
//                     fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
//                     fonts.AddFont("AnonymousPro-Regular.ttf", "AnonymousPro");
//                 });

// #if DEBUG
//     		builder.Logging.AddDebug();
// #endif

//             return builder.Build();
//         }
//     }
// }
