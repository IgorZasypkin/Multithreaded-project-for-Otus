using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus
{
    public class AsyncTimeMeasurer
    {
        public async Task<(long result, long elapsedMs)> MeasureTimeAsync(Func<Task<long>> func)
        {
            var sw = Stopwatch.StartNew();
            var result = await func();
            sw.Stop();
            return (result, sw.ElapsedMilliseconds);
        }
    }
}
