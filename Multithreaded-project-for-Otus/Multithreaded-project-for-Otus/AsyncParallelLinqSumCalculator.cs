using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class AsyncParallelLinqSumCalculator : ISumCalculator
    {
        public string MethodName => "Асинхронная параллельная сумма (LINQ)";

        public async Task<long> CalculateSumAsync(int[] array)
        {
            return await Task.Run(() => array.AsParallel().Sum(x => (long)x));
        }
    }
}
