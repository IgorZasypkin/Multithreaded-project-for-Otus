using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class ParallelLinqSumCalculator : ISumCalculator
    {
        public string MethodName => "Параллельная сумма (LINQ)";

        public long CalculateSum(int[] array)
        {
            return array.AsParallel().Sum(x => (long)x);
        }
    }
}
