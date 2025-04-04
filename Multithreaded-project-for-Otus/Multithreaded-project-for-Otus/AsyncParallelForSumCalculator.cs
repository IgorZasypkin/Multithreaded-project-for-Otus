using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class AsyncParallelForSumCalculator : ISumCalculator
    {
        public string MethodName => "Асинхронная сумма (Parallel.For)";

        public async Task<long> CalculateSumAsync(int[] array)
        {
            return await Task.Run(() =>
            {
                long total = 0;
                Parallel.For(0, array.Length,
                    () => 0L, // Инициализация локальной переменной потока
                    (i, state, localSum) => localSum + array[i], // Тело цикла
                    localSum => Interlocked.Add(ref total, localSum)); // Финализация
                return total;
            });
        }
    }
}
