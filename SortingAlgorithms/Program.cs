using Autofac;
using SortingAlgorithms.Services;
using System;

namespace SortingAlgorithms
{
    class Program
    {
        private static IContainer Container { get; set; }
        private static ITimerService _timerService;
        private static ISort _sortService;

        static void Main(string[] args)
        {
            RegisterDependencies();
            int[] unsortedNumbers;
            
            using(var scope = Container.BeginLifetimeScope())
            {
                _timerService = scope.Resolve<ITimerService>();

                unsortedNumbers = new int[] { 7, 2, 1, 6, 8, 5, 3, 4 };
                var heapSort = new HeapSort(_timerService);
                Sort(heapSort, unsortedNumbers);

                unsortedNumbers = new int[] { 7, 2, 1, 6, 8, 5, 3, 4 };
                var mergeSort = new MergeSort(_timerService);
                Sort(mergeSort, unsortedNumbers);

                unsortedNumbers = new int[] { 7, 2, 1, 6, 8, 5, 3, 4 };
                var quickSort = new QuickSort(_timerService);
                Sort(quickSort, unsortedNumbers);
            }
        }

        private static void Sort(ISort sortService, int[] array)
        {
             PrintArray(array);
             sortService.Sort(array);
             PrintArray(array);
        }

        private static void PrintArray(int[] array)
        {
            Console.Write("\n");

            foreach (var num in array)
                Console.Write(num + "\t");

            Console.Write("\n");
        }

        private static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TimerService>().As<ITimerService>();
            Container = builder.Build();
        }
    }
}
