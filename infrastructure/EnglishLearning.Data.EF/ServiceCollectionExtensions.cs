using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Data.EF
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<EnglishLearningDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            },
            ServiceLifetime.Transient);

            services.AddSingleton<IWordRepository, WordRepository>();

            return services;
        }
    }
}
