using EnglishLearning.App.Services;
using EnglishLearning.App.ViewModels;
using EnglishLearning.Data.EF;
using EnglishLearning.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace EnglishLearning.App
{
    public class ViewModelLocator
    {
        private static IHost host;

        public static void Init()
        {
            host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddTransient<MainWindowVM>();
                services.AddTransient<LearningPageVM>();
                services.AddTransient<WordTranslationPageVM>();
                services.AddTransient<ListeningPageVM>();
                services.AddTransient<DictionaryPageVM>();

                services.AddEfRepositories(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

                services.AddSingleton<WordService>();
                services.AddSingleton<PageService>();
            }).Build();
        }

        public LearningPageVM LearningPageVM => host.Services.GetRequiredService<LearningPageVM>();
        public MainWindowVM MainWindowVM => host.Services.GetRequiredService<MainWindowVM>();
        public WordTranslationPageVM WordTranslationPageVM => host.Services.GetRequiredService<WordTranslationPageVM>();
        public ListeningPageVM ListeningPageVM => host.Services.GetRequiredService<ListeningPageVM>();
        public DictionaryPageVM DictionaryPageVM => host.Services.GetRequiredService<DictionaryPageVM>();
    }
}
