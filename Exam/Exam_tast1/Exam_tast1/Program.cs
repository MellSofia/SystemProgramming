using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MultiThreadedSorting
{
    internal class Program
    {
        private static int[] originalArray;
        private static int[] sortedArray;
        private static int numberOfThreads;
        private static object lockObject = new object();

        static void Main(string[] args)
        {
            int arraySize = GetPositiveInteger("Введите размер массива: ");
            numberOfThreads = GetNumberOfThreads(arraySize);

            originalArray = new int[arraySize];
            Random random = new Random();
            for (int i = 0; i < arraySize; i++)
            {
                originalArray[i] = random.Next(1, 100);
            }

            Console.WriteLine("Оригинальный массив: " + string.Join(", ", originalArray));
            int partSize = originalArray.Length / numberOfThreads;
            List<Thread> threads = new List<Thread>();
            List<int[]> sortedParts = new List<int[]>();

            for (int i = 0; i < numberOfThreads; i++)
            {
                int start = i * partSize;
                int end = (i == numberOfThreads - 1) ? originalArray.Length : start + partSize;

                int[] part = new int[end - start];
                Array.Copy(originalArray, start, part, 0, part.Length);
                sortedParts.Add(part);

                Thread thread = new Thread(() => SortPart(part));
                threads.Add(thread);
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            sortedArray = sortedParts.SelectMany(x => x).ToArray();
            Array.Sort(sortedArray);
            Console.WriteLine("Итоговый отсортированный массив: " + string.Join(", ", sortedArray));
        }

        static void SortPart(int[] part)
        {
            Array.Sort(part);
            Console.WriteLine($"Отсортированная часть: {string.Join(", ", part)}");
        }

        static int GetPositiveInteger(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result) && result > 0)
                {
                    return result;
                }
                Console.WriteLine("Пожалуйста, введите положительное целое число.");
            }
        }

        static int GetNumberOfThreads(int arraySize)
        {
            int threads;
            while (true)
            {
                threads = GetPositiveInteger("Введите количество потоков (не больше размера массива): ");
                if (threads <= arraySize)
                {
                    return threads;
                }
                Console.WriteLine($"Количество потоков не может превышать размер массива ({arraySize}).");
            }
        }
    }
}