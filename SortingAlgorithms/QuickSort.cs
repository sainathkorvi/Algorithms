using SortingAlgorithms.Services;
using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class QuickSort : ISort
    {
        private ITimerService _timer;
        public QuickSort(ITimerService timer)
        {
            _timer = timer;
        }
        public void Sort(IList<int> list)
        {
            Console.WriteLine("******Quick Sort*******");
            _timer.Start();
            Sort(list, 0, list.Count - 1);
            Console.WriteLine("Time taken to sort using quick sort = " + _timer.GetTimerValue() + " MilliSeconds");
        }

        private void Sort(IList<int> list, int start, int end)
        {
            if (end - start <= 0) return;

            int pivot = list[end];
            int wall = start;

            for(int i = start; i <= end; i++)
            {
                //dynamic value = list[i];

                if (list[i] < pivot)
                {
                    Swap(list, i, wall);
                    wall++;
                }
            }

            Swap(list, wall, end);
            Sort(list, start, wall - 1);
            Sort(list, wall, end);
        }

        private void Swap(IList<int> list, int pos1, int pos2)
        {
            int temp = list[pos1];
            list[pos1] = list[pos2];
            list[pos2] = temp;
        }
    }
}
