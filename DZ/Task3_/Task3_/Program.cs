using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_MainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string processPath = "Task3_ChildProc.exe";

                Console.WriteLine("Введите первое число:");
                string num1 = Console.ReadLine();

                Console.WriteLine("Введите второе число:");
                string num2 = Console.ReadLine();

                Console.WriteLine("Введите операцию (+, -, *, /):");
                string operation = Console.ReadLine();

                Process process = new Process();
                process.StartInfo.FileName = processPath;
                process.StartInfo.Arguments = $"{num1} {num2} {operation}";
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
