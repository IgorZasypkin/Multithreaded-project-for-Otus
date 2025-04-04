using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class AsyncChunkedSumCalculator : ISumCalculator
    {
        public string MethodName => "Асинхронная чанкованная сумма";

        public async Task<long> CalculateSumAsync(int[] array)
        {
            const int chunkSize = 10_000;
            var chunks = array.Chunk(chunkSize);
            var tasks = new List<Task<long>>();

            foreach (var chunk in chunks)
            {
                tasks.Add(ProcessChunkAsync(chunk));
            }

            var results = await Task.WhenAll(tasks);
            return results.Sum();
        }

        private async Task<long> ProcessChunkAsync(int[] chunk)
        {
            return await Task.Run(() =>
            {
                long sum = 0;
                foreach (var num in chunk)
                {
                    sum += num;
                }
                return sum;
            });
        }
    }
}
