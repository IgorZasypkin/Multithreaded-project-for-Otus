using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class AsyncRandomArrayGenerator : IArrayGenerator
    {
        public async Task<int[]> GenerateRandomArrayAsync(int size)
        {
            return await Task.Run(() =>
            {
                var rand = new Random();
                var array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = rand.Next(1, 100);
                }
                return array;
            });
        }
    }
}
