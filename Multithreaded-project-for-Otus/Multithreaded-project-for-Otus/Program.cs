using Microsoft.Extensions.DependencyInjection;
using Multithreaded_project_for_Otus;
using Multithreaded_project_for_Otus.Interface;
using System;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        var app = serviceProvider.GetRequiredService<AsyncSumCalculatorApp>();
        await app.RunAsync();
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddTransient<IArrayGenerator, AsyncRandomArrayGenerator>();
        services.AddTransient<ISumCalculator, AsyncSequentialSumCalculator>();
        services.AddTransient<ISumCalculator, AsyncThreadSumCalculator>();
        services.AddTransient<ISumCalculator, AsyncParallelLinqSumCalculator>();
        services.AddSingleton<AsyncTimeMeasurer>();
        services.AddTransient<AsyncSumCalculatorApp>();

        return services.BuildServiceProvider();
    }
}