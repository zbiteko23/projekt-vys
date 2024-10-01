using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string[] slova = File.ReadAllLines("slova.txt");
        Random rand = new Random();
        string vybraneSlovo = slova[rand.Next(slova.Length)].ToUpper();
        HashSet<char> spravnePismena = new HashSet<char>();
        int pokusy = 6;

        while (pokusy > 0)
        {
            Console.Clear();
            VypisSlovo(vybraneSlovo, spravnePismena);
            Console.WriteLine($"Zbývající pokusy: {pokusy}");
            Console.Write("Zadejte písmeno: ");
            char pismeno = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (spravnePismena.Contains(pismeno))
            {
                Console.WriteLine("Toto písmeno jste už zvolili.");
                continue;
            }

            spravnePismena.Add(pismeno);

            if (!vybraneSlovo.Contains(pismeno))
            {
                pokusy--;
                Console.WriteLine($"Písmeno '{pismeno}' není ve slově.");
            }

            if (Vyhral(jakVypadaSlovo(vybraneSlovo, spravnePismena)))
            {
                Console.Clear();
                VypisSlovo(vybraneSlovo, spravnePismena);
                Console.WriteLine("Gratulujeme! Vyhráli jste!");
                return;
            }
        }

        Console.WriteLine($"Prohráli jste! Správné slovo bylo: {vybraneSlovo}");
    }

    static void VypisSlovo(string slovo, HashSet<char> spravnePismena)
    {
        foreach (char p in slovo)
        {
            if (spravnePismena.Contains(p))
                Console.Write(p + " ");
            else
                Console.Write("_ ");
        }
        Console.WriteLine();
    }

    static string jakVypadaSlovo(string slovo, HashSet<char> spravnePismena)
    {
        string vysledek = "";
        foreach (char p in slovo)
        {
            vysledek += spravnePismena.Contains(p) ? p : '_';
        }
        return vysledek;
    }

    static bool Vyhral(string slovo)
    {
        return !slovo.Contains('_');
    }
}

