using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class AsyncSequentialSumCalculator : ISumCalculator
    {
        public string MethodName => "Асинхронная последовательная сумма";

        public async Task<long> CalculateSumAsync(int[] array)
        {
            return await Task.Run(() =>
            {
                long sum = 0;
                foreach (int num in array)
                {
                    sum += num;
                }
                return sum;
            });
        }
    }
}
