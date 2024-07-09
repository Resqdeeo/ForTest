using Microsoft.Extensions.DependencyInjection;
using TestSite.API.Application.Interfaces;
using TestSite.API.Persistence.Context;

namespace TestSite.API.Persistence;

public static class Entry
{
    public static void AddPersistenceLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<EfContext>();
        serviceCollection.AddScoped<IDbContext, EfContext>();
        serviceCollection.AddTransient<Migrator>();
        serviceCollection.AddLogging();
    }
}