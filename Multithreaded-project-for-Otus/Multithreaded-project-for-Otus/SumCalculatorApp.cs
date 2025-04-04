using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class SumCalculatorApp
    {
        private readonly IArrayGenerator _arrayGenerator;
        private readonly IEnumerable<ISumCalculator> _sumCalculators;
        private readonly TimeMeasurer _timeMeasurer;

        public SumCalculatorApp(
            IArrayGenerator arrayGenerator,
            IEnumerable<ISumCalculator> sumCalculators,
            TimeMeasurer timeMeasurer)
        {
            _arrayGenerator = arrayGenerator;
            _sumCalculators = sumCalculators;
            _timeMeasurer = timeMeasurer;
        }

        public void Run()
        {
            int[] sizes = { 100_000, 1_000_000, 10_000_000 };

            foreach (int size in sizes)
            {
                Console.WriteLine($"\nРазмер массива: {size:N0}");
                int[] array = _arrayGenerator.GenerateRandomArray(size);

                foreach (var calculator in _sumCalculators)
                {
                    var (result, elapsedMs) = _timeMeasurer.MeasureTime(() => calculator.CalculateSum(array));
                    Console.WriteLine($"{calculator.MethodName}: {result}");
                    Console.WriteLine($"Время выполнения: {elapsedMs} мс");
                }
            }
        }
    }
}
