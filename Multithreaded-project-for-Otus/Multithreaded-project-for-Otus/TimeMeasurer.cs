using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class TimeMeasurer
    {
        public (long result, long elapsedMs) MeasureTime(Func<long> action)
        {
            var sw = Stopwatch.StartNew();
            long result = action();
            sw.Stop();
            return (result, sw.ElapsedMilliseconds);
        }
    }
}
