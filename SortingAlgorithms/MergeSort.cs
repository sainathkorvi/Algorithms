using SortingAlgorithms.Services;
using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    class MergeSort : ISort
    {
        private ITimerService _timer;
        public MergeSort(ITimerService timer)
        {
            _timer = timer;
        }
        public void Sort(IList<int> list)
        {
            Console.WriteLine("******Merge Sort*******");
            _timer.Start();
            Sort(list, new int[list.Count], 0, list.Count - 1);
            Console.WriteLine("Time taken to sort using merge sort = " + _timer.GetTimerValue() + " MilliSeconds");
        }

        private void Sort(IList<int> list, int[] temp, int start, int end)
        {
            if (end - start <= 0) return;

            int mid = (start + end) / 2;

            Sort(list, temp, start, mid);
            Sort(list, temp, mid + 1, end);
            Merge(list, temp, start, end);
        }

        private void Merge(IList<int> list, int[] tempList, int start, int end)
        {
            //var tempList = new List<int>();

            int sideA = start;
            int mid = (start + end) / 2;
            int sideB = mid + 1;
            int k = 0, i = 0, tempStart = start;

            while (sideA <= mid && sideB <= end)
            {
                if(list[sideA] > list[sideB])
                {
                    //tempList.Add(list[sideB]);
                    tempList[k] = list[sideB];
                    sideB++;
                }
                else
                {
                    //tempList.Add(list[sideA]);
                    tempList[k] = list[sideA];
                    sideA++;
                }
                k++;
            }

            while(sideA <= mid)
            {
                //tempList.Add(list[sideA]);
                tempList[k] = list[sideA];
                sideA++;
                k++;
            }
            while(sideB <= end)
            {
                //tempList.Add(list[sideB]);
                tempList[k] = list[sideB];
                sideB++;
                k++;
            }

            while(i < k)
            {
                list[tempStart] = tempList[i];
                tempStart++;
                i++;
            }
        }
    }
}
