using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Infrastructure
{
    public static class PersistentStorageDependencies
    {
        public static void AddPersistentStorageDependencies(this IServiceCollection services)
        {
            services.AddDbContext<BookManagerDbContext>(options
                => options.UseInMemoryDatabase(databaseName: "BookManager"));
        }
    }
}
