using System;
using System.Diagnostics;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Запущена программа. Процесс имеет имя: {Process.GetCurrentProcess().ProcessName}");
                Console.WriteLine($"ID процесса программы: {Process.GetCurrentProcess().Id}");

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    UseShellExecute = false, 
                    CreateNoWindow = true 
                };

                Process process = new Process();
                process.StartInfo = startInfo;

                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Открыть блокнот и ожидать завершения процесса");
                Console.WriteLine("2 - Принудительно завершить процесс");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    process.Start();
                    Console.WriteLine("Блокнот открыт.");
                    process.WaitForExit();
                    Console.WriteLine($"Дочерний процесс завершен. Код завершения: {process.ExitCode}");
                }
                else if (choice == "2")
                {
                    process.Start();
                    Console.WriteLine("Блокнот открыт, но будет немедленно завершен.");
                    process.Kill();
                    Console.WriteLine("Дочерний процесс был принудительно завершен.");
                }
                else
                {
                    Console.WriteLine("Неверный выбор.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}