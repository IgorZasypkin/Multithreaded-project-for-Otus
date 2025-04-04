using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreaded_project_for_Otus.Interface
{
    public interface IArrayGenerator
    {
        Task<int[]> GenerateRandomArrayAsync(int size);
    }
}
