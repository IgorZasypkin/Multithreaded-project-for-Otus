using Microsoft.Extensions.DependencyInjection;
using Multithreaded_project_for_Otus;
using Multithreaded_project_for_Otus.Interface;
using System;

class Program
{
    static void Main()
    {
        var serviceProvider = ConfigureServices();

        var app = serviceProvider.GetRequiredService<SumCalculatorApp>();
        app.Run();
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Регистрация сервисов
        services.AddTransient<IArrayGenerator, RandomArrayGenerator>();
        services.AddTransient<ISumCalculator, SequentialSumCalculator>();
        services.AddTransient<ISumCalculator, ParallelThreadSumCalculator>();
        services.AddTransient<ISumCalculator, ParallelLinqSumCalculator>();
        services.AddSingleton<TimeMeasurer>();
        services.AddTransient<SumCalculatorApp>();

        return services.BuildServiceProvider();
    }
}