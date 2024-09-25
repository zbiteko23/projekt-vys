using System;

namespace KamenNuzkyPapir
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string[] options = { "kámen", "nůžky", "papír" };
            string userChoice;
            string computerChoice;
            string playAgain;

            do
            {
                Console.WriteLine("Vyberte si: kámen, nůžky nebo papír:");
                userChoice = Console.ReadLine().ToLower();

                while (Array.IndexOf(options, userChoice) == -1)
                {
                    Console.WriteLine("Zkuste to znovu: kámen, nůžky nebo papír:");
                    userChoice = Console.ReadLine().ToLower();
                }

                int computerChoiceIndex = random.Next(0, options.Length);
                computerChoice = options[computerChoiceIndex];

                Console.WriteLine($"Počítač si vybral: {computerChoice}");

                if (userChoice == computerChoice)
                {
                    Console.WriteLine("Remíza!");
                }
                else if ((userChoice == "kámen" && computerChoice == "nůžky") ||
                         (userChoice == "nůžky" && computerChoice == "papír") ||
                         (userChoice == "papír" && computerChoice == "kámen"))
                {
                    Console.WriteLine("Vyhrál jsi!");
                }
                else
                {
                    Console.WriteLine("Prohrál jsi!");
                }

                Console.WriteLine("Chceš hrát znovu? (ne/ne)");
                playAgain = Console.ReadLine().ToLower();

            } while (playAgain == "ne");

            Console.WriteLine("Dik za hru!");
        }
    }
}
