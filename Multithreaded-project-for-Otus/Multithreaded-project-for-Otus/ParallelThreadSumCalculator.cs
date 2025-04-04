using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class ParallelThreadSumCalculator : ISumCalculator
    {
        public string MethodName => "Параллельная сумма (Thread)";

        public long CalculateSum(int[] array)
        {
            int threadCount = Environment.ProcessorCount;
            int chunkSize = array.Length / threadCount;

            var threads = new List<Thread>();
            var results = new long[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                int threadIndex = i;
                int start = threadIndex * chunkSize;
                int end = (threadIndex == threadCount - 1) ? array.Length : start + chunkSize;

                Thread thread = new Thread(() =>
                {
                    long localSum = 0;
                    for (int j = start; j < end; j++)
                    {
                        localSum += array[j];
                    }
                    results[threadIndex] = localSum;
                });

                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            return results.Sum();
        }
    }
}
