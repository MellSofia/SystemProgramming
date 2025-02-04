using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //string processPath = "C:\\Users\\Student_06\\Desktop\\Ахмутдиновой\\DZ\\Task4_\\Task4_ChildProc.exe";
                string processPath = "Task4_ChildProc.exe";

                string filePath = "task.txt";

                Console.WriteLine("Введите слово для поиска:");
                string word = Console.ReadLine();

                Process process = new Process();
                process.StartInfo.FileName = processPath;
                process.StartInfo.Arguments = $"\"{filePath}\" {word}";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
