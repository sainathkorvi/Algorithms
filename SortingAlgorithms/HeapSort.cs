using SortingAlgorithms.Services;
using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    class HeapSort : ISort
    {
        private ITimerService _timer;
        public HeapSort(ITimerService timer)
        {
            _timer = timer;
        }
        public void Sort(IList<int> list)
        {
            Console.WriteLine("******Heap Sort*******");
            _timer.Start();
            Sort(list, list.Count);
            Console.WriteLine("Time taken to sort using heap sort = " + _timer.GetTimerValue() + " MilliSeconds");
        }

        private void Sort(IList<int> list, int size)
        {
            for(int i = size/2 - 1; i >= 0; i--)
            {
                Heapify(list, size, i);
            }

            for(int i = size - 1; i >= 0; i--)
            {
                Swap(list, 0, i);
                Heapify(list, i, 0);
            }
        }

        private void Heapify(IList<int> list, int size, int index)
        {
            int largest = index;
            int left = largest * 2 + 1;
            int right = largest * 2 + 2;

            if (left < size && list[largest] < list[left])
                largest = left;

            if (right < size && list[largest] < list[right])
                largest = right;

            if(largest != index)
            {
                Swap(list, largest, index);
                Heapify(list, size, largest);
            }
        }

        private void Swap(IList<int> list, int pos1, int pos2)
        {
            var temp = list[pos1];
            list[pos1] = list[pos2];
            list[pos2] = temp;
        }
    }
}
