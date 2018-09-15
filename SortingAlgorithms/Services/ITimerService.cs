using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Services
{
    public interface ITimerService
    {
        void Start();
        int GetTimerValue();

    }
}
