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

            services.AddScoped<StudyWindowVM>();

            services.AddSingleton<IWordRepository, WordRepository> ();

            provider = services.BuildServiceProvider();

            foreach (var item in services)
            {
                provider.GetRequiredService(item.ServiceType);
            }
        }

        public StudyWindowVM StudyWindowVM => provider.GetRequiredService<StudyWindowVM>();
    }
}
