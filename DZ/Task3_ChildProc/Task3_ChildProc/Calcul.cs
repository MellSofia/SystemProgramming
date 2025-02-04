using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_ChildProc
{
    internal class Calcul
    {
        static void Main(string[] args)
        {

            if (args.Length != 3)
            {
                Console.WriteLine("Неверное количество аргументов.");
                return;
            }

            try
            {
                int num1 = int.Parse(args[0]);
                int num2 = int.Parse(args[1]);
                string operation = args[2];
                int result = 0;
                switch (operation) 
                {
                    case ("+"):
                        result = num1 + num2;
                        break;
                    case ("-"):
                        result = num1 - num2; 
                        break;
                    case ("*"):
                        result = num1 * num2;
                        break;
                    case ("/"):
                        result = num1 / num2;
                        break;
                    default:
                        Console.WriteLine("Неверная операция");
                        break;
                }
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
