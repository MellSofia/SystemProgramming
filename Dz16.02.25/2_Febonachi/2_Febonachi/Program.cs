using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        long start = 0;
        long end = 500;
        long numberOfThreads = 100;
        Task[] tasks = new Task[numberOfThreads];

        long rangeSize = (end - start + 1) / numberOfThreads;

        for (long i = 0; i < numberOfThreads; i++)
        {
            long rangeStart = start + i * rangeSize;
            long rangeEnd = (i == numberOfThreads - 1) ? end : rangeStart + rangeSize - 1;

            tasks[i] = Task.Run(() => CalculateFibonacci(rangeStart, rangeEnd));
        }

        Task.WaitAll(tasks);
        Console.ReadKey();
    }

    static void CalculateFibonacci(long start, long end)
    {
        for (long i = start; i <= end; i++)
        {
            Console.WriteLine($"Fibonacci({i}) = {Fibonacci(i)}");
        }
    }

    static long Fibonacci(long n)
    {
        long[] a = new long[n + 5];
        a[1] = 1;
        a[2] = 1;
        for (long i = 3; i < n + 5; i++)
        {
            a[i] = a[i - 1] + a[i - 2];
        }
        return a[n + 1];
    }
}