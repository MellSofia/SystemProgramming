using System;
using System.Threading;

class Program
{
    static int guessedNumber;
    static bool isGuessed = false;
    static object lockObj = new object();
    static int winnerId;
    static int winnerAttempts;

    static void Main(string[] args)
    {
        int playersCount = GetPositiveInteger("Введите количество игроков: ");

        Random random = new Random();
        guessedNumber = random.Next(1, 101);
        Console.WriteLine("Число загадано! Игроки, угадайте его!");

        Thread[] threads = new Thread[playersCount];
        for (int i = 0; i < playersCount; i++)
        {
            int playerId = i + 1;
            threads[i] = new Thread(() => PlayerGuess(playerId));
            threads[i].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine($"Победитель: Игрок {winnerId} угадал число {guessedNumber} за {winnerAttempts} попыток!");
    }

    static void PlayerGuess(int playerId)
    {
        int attempts = 0;
        while (!isGuessed)
        {
            lock (lockObj)
            {
                if (isGuessed) return;

                Console.Write($"Игрок {playerId}, введите ваше предположение: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int guess))
                {
                    attempts++;

                    if (guess == guessedNumber)
                    {
                        isGuessed = true;
                        winnerId = playerId;
                        winnerAttempts = attempts;
                    }
                    else if (guess < guessedNumber)
                    {
                        Console.WriteLine("Загаданное число больше!");
                    }
                    else
                    {
                        Console.WriteLine("Загаданное число меньше!");
                    }
                }
                else
                {
                    Console.WriteLine("Пожалуйста, введите корректное целое число.");
                }
            }
        }
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
}