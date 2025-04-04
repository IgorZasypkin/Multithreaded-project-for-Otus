using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class AsyncSumCalculatorApp
    {
        private readonly IArrayGenerator _arrayGenerator;
        private readonly IEnumerable<ISumCalculator> _sumCalculators;
        private readonly AsyncTimeMeasurer _timeMeasurer;

        public AsyncSumCalculatorApp(
            IArrayGenerator arrayGenerator,
            IEnumerable<ISumCalculator> sumCalculators,
            AsyncTimeMeasurer timeMeasurer)
        {
            _arrayGenerator = arrayGenerator;
            _sumCalculators = sumCalculators;
            _timeMeasurer = timeMeasurer;
        }

        public async Task RunAsync()
        {
            int[] sizes = { 100_000, 1_000_000, 10_000_000 };

            foreach (var size in sizes)
            {
                Console.WriteLine($"\nРазмер массива: {size:N0}");
                var array = await _arrayGenerator.GenerateRandomArrayAsync(size);

                foreach (var calculator in _sumCalculators)
                {
                    var (result, elapsedMs) = await _timeMeasurer.MeasureTimeAsync(
                        () => calculator.CalculateSumAsync(array));

                    Console.WriteLine($"{calculator.MethodName}: {result}");
                    Console.WriteLine($"Время выполнения: {elapsedMs} мс");
                }
            }
        }
    }
}
