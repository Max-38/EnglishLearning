using EnglishLearning.App.Services;
using EnglishLearning.App.ViewModels;
using EnglishLearning.Memory;
using EnglishLearning.Services;
using Microsoft.Extensions.DependencyInjection;


namespace EnglishLearning.App
{
    public class ViewModelLocator
    {
        private static ServiceProvider provider;

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddScoped<MainWindowVM>();
            services.AddTransient<LearningPageVM>();
            services.AddTransient<WordTranslationPageVM>();
            services.AddTransient<ListeningPageVM>();
            services.AddTransient<DictionaryPageVM>();

            services.AddSingleton<IWordRepository, WordRepository> ();
            services.AddSingleton<WordService>();
            services.AddSingleton<PageService>();

            provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                provider.GetRequiredService(item.ServiceType);
            }
        }

        public LearningPageVM LearningPageVM => provider.GetRequiredService<LearningPageVM>();
        public MainWindowVM MainWindowVM => provider.GetRequiredService<MainWindowVM>();
        public WordTranslationPageVM WordTranslationPageVM => provider.GetRequiredService<WordTranslationPageVM>();
        public ListeningPageVM ListeningPageVM => provider.GetRequiredService<ListeningPageVM>();
        public DictionaryPageVM DictionaryPageVM => provider.GetRequiredService<DictionaryPageVM>();
    }
}
