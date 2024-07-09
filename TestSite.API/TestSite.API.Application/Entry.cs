﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TestSite.API.Application.Models;

namespace TestSite.API.Application;

public static class Entry
{
    public static void AddApplicationLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Entry).Assembly));
        serviceCollection.Configure<FrontendSettings>(configuration.GetSection("FrontendSettings"));
        serviceCollection.AddSingleton(provider => provider.GetRequiredService<IOptions<FrontendSettings>>().Value);
    }
}