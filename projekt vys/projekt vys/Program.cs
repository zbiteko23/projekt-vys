using System;

namespace KamenNuzkyPapir
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] options = { "Kámen", "Nůžky", "Papír" };
            Random random = new Random();

            Console.WriteLine("Hrajeme Kámen, Nůžky, Papír!");
            Console.WriteLine("Zadej 0 pro Kámen, 1 pro Nůžky, 2 pro Papír:");

            int playerChoice = int.Parse(Console.ReadLine());

            if (playerChoice < 0 || playerChoice > 2)
            {
                Console.WriteLine("Neplatná volba!");
                return;
            }

            int computerChoice = random.Next(0, 3);

            Console.WriteLine($"Tvoje volba: {options[playerChoice]}");
            Console.WriteLine($"Volba počítače: {options[computerChoice]}");

            if (playerChoice == computerChoice)
            {
                Console.WriteLine("Remíza!");
            }
            else if ((playerChoice == 0 && computerChoice == 1) ||
                     (playerChoice == 1 && computerChoice == 2) ||
                     (playerChoice == 2 && computerChoice == 0))
            {
                Console.WriteLine("Vyhrál jsi!");
            }
            else
            {
                Console.WriteLine("Prohrál jsi!");
            }

            Console.WriteLine("Stiskni libovolnou klávesu pro ukončení...");
            Console.ReadKey();
        }
    }
}