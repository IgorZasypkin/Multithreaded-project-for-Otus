using Multithreaded_project_for_Otus.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class SequentialSumCalculator : ISumCalculator
    {
        public string MethodName => "Последовательная сумма";

        public long CalculateSum(int[] array)
        {
            long sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            return sum;
        }
    }
}
