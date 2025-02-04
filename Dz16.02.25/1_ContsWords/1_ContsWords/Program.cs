using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "test.txt";
        int numberOfThreads = 4;
        long totalWords = 0;

        string[] lines = File.ReadAllLines(filePath);
        int linesPerThread = lines.Length / numberOfThreads;
        Task<long>[] tasks = new Task<long>[numberOfThreads];

        for (int i = 0; i < numberOfThreads; i++)
        {
            int start = i * linesPerThread;
            int end = (i == numberOfThreads - 1) ? lines.Length : start + linesPerThread;

            tasks[i] = Task.Run(() => CountWords(lines, start, end));
        }

        Task.WaitAll(tasks);

        foreach (var task in tasks)
        {
            totalWords += task.Result;
        }

        Console.WriteLine($"Всего слов в файле: {totalWords}");
    }

    static long CountWords(string[] lines, int start, int end)
    {
        long count = 0;
        for (int i = start; i < end; i++)
        {
            count += lines[i].Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        return count;
    }
}