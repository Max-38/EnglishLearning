using EnglishLearning.App.Services;
using EnglishLearning.App.ViewModels;
using EnglishLearning.Memory;
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
            services.AddTransient<DictionaryPageVM>();

            services.AddSingleton<IWordRepository, WordRepository> ();
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
        public DictionaryPageVM DictionaryPageVM => provider.GetRequiredService<DictionaryPageVM>();
    }
}
