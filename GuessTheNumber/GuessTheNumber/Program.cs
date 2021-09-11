using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random number = new Random();
            int secretNumber = number.Next(1, 100);
            int guess = 0;

            while (guess != secretNumber)
            {
                Console.WriteLine("What is your guess?");
                string guessText = Console.ReadLine();

                guess = int.Parse(guessText);
                if (guess == secretNumber)
                {
                    Console.WriteLine("You guess correctly!");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("You guessed too high...");
                }
                else if (guess < secretNumber)
                {
                    Console.WriteLine("You guessed too low...");
                }
            }
        }
    }
}
