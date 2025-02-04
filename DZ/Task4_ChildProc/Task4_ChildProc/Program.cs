using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4_ChildProc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Неверное количество аргументов.");
                return;
            }

            try
            {
                string filePath = args[0];
                string word = args[1];

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }

                string content = File.ReadAllText(filePath);
                int count = content.Split(new[] { word }, StringSplitOptions.None).Length - 1;

                Console.WriteLine($"Слово \"{word}\" встречается {count} раз(а).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
