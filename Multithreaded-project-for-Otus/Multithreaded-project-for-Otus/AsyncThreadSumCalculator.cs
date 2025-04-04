using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class AsyncThreadSumCalculator : ISumCalculator
    {
        public string MethodName => "Асинхронная сумма (Thread)";

        public async Task<long> CalculateSumAsync(int[] array)
        {
            return await Task.Run(() => CalculateWithThreads(array));
        }

        private long CalculateWithThreads(int[] array)
        {
            int threadCount = Environment.ProcessorCount;
            int chunkSize = array.Length / threadCount;
            long total = 0;
            var threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                int start = i * chunkSize;
                int end = (i == threadCount - 1) ? array.Length : start + chunkSize;

                threads[i] = new Thread(() =>
                {
                    long localSum = 0;
                    for (int j = start; j < end; j++)
                    {
                        localSum += array[j];
                    }
                    Interlocked.Add(ref total, localSum);
                });

                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return total;
        }
    }
}
