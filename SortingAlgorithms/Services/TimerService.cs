using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Services
{
    public class TimerService : ITimerService
    {
        private DateTime _current = DateTime.MaxValue;

        public int GetTimerValue()
        {
            return _current == DateTime.MaxValue ? 0 : (DateTime.Now - _current).Milliseconds;
        }

        public void Start()
        {
            _current = DateTime.Now;
        }
    }
}
