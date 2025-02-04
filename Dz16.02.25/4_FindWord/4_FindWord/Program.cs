using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string[] array = { "яблоко", "Банан", "вишня", "лимон", "яблоко", "апельсин", "яблоко" };
        string wordToFind = "яблоко";
        int numberOfThreads = 4;
        int foundCount = 0;

        Task<int>[] tasks = new Task<int>[numberOfThreads];
        int chunkSize = array.Length / numberOfThreads;

        for (int i = 0; i < numberOfThreads; i++)
        {
            int start = i * chunkSize;
            int end = (i == numberOfThreads - 1) ? array.Length : start + chunkSize;

            tasks[i] = Task.Run(() => CountOccurrences(array, wordToFind, start, end));
        }

        Task.WaitAll(tasks);

        foreach (var task in tasks)
        {
            foundCount += task.Result;
        }

        Console.WriteLine($"Слово '{wordToFind}' было найдено {foundCount} раза.");
    }

    static int CountOccurrences(string[] array, string word, int start, int end)
    {
        int count = 0;
        for (int i = start; i < end; i++)
        {
            if (array[i].Equals(word, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }
        return count;
    }
}