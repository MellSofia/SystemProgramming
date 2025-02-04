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
                Console.WriteLine($"Запущена программа. Процесс имеет имя: {Process.GetCurrentProcess().ProcessName}");
                Console.WriteLine($"ID процесса программы: {Process.GetCurrentProcess().Id}");

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    UseShellExecute = true
                };

                Console.WriteLine("\n\nЗапускаем блокнот.");
                Process process = Process.Start(startInfo);

                Console.WriteLine($"ID процесса: {process.Id}");
                Console.WriteLine($"Имя процесса: {process.ProcessName}");
                Console.WriteLine($"Приоритет: {process.BasePriority}");
                Console.WriteLine($"Имя компьютера: {process.MachineName}");
                Console.WriteLine($"Главный модуль: {process.MainModule}");

                Console.WriteLine("Ожидание закрытия дочернего процесса.");
                process.WaitForExit();

                Console.WriteLine($"Дочерний процесс завершен. Код завершения: {process.ExitCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
