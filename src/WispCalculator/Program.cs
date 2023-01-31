namespace WispCalculator;
using System;
using System.IO;
internal class Program
{
    private const int c_maxPermutations = 64;

    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to >>> Infini-wisp solver 1.0 <<<!");
        Console.WriteLine();
        Console.WriteLine("Important Note: this is a bruteforce implementation, it's preferable to have a strong PC.");
        Console.WriteLine();
        int maxMods = 50;
        while (true)
        {
            Console.WriteLine("> Enter targeted lifetime values <");

            min:
            Console.WriteLine("Enter minimum projectile lifetime: ");
            bool valid = Int32.TryParse(Console.ReadLine(), out int minLifetime);
            if (!valid) { Console.WriteLine("Invalid input! Try again"); goto min; }

            max:
            Console.WriteLine("Enter maximum projectile lifetime (same as min if no lifetime randomness): ");
            valid = Int32.TryParse(Console.ReadLine(), out int maxLifetime);
            if (!valid) { Console.WriteLine("Invalid input! Try again"); goto max; }

            if (minLifetime > maxLifetime || minLifetime < 0 || maxLifetime < 0) { Console.WriteLine("Invalid lifetime values! Try again"); goto min; };

            if (maxLifetime > 1500)
                maxMods = 60;
            if (maxLifetime > 2000)
                maxMods = 80;
            if (maxLifetime > 2500)
                maxMods = 100;

            Console.WriteLine("Please wait for the solver to finish calculating...");
            Console.WriteLine();
            var wispList = Solver.Filter(minLifetime, maxLifetime, maxMods);

            if (args.Length > 0 && args[0] == "csv")
                OutputCSV(wispList, minLifetime, maxLifetime);
            else
                OutputConsole(wispList, minLifetime, maxLifetime);

            Console.WriteLine();
            Console.WriteLine("Press any key to repeat the process or simply close the program");
            Console.WriteLine();
            Console.ReadKey();
        }

    }
    static void OutputConsole(spellSet[,] wispList, int minLifetime, int maxLifetime)
    {
        for (int i = minLifetime; i < maxLifetime + 1; i++)
        {
            Console.WriteLine($"LIFETIME = {-(i + 1)}");
            bool possible = false;
            for (int s = 0; s < c_maxPermutations; s++)
            {
                spellSet currPermutation = wispList[i, s];
                if (currPermutation.count > 0)
                {
                    Console.WriteLine($"Permutation #{s + 1}");
                    Console.WriteLine($"Count = {currPermutation.count}");
                    Console.WriteLine(currPermutation);
                    possible = true;
                }
            }
            if (!possible) Console.WriteLine("A wisp with this configuration is impossible");
        }
    }
    static void OutputCSV(spellSet[,] wispList, int minLifetime, int maxLifetime)
    {
        using (StreamWriter file = new StreamWriter($"wisp from {minLifetime} to {maxLifetime}.csv"))
        {
            file.Write("decrease, increase, chain, phasing, orbit/pingpong, spiral, count");

            for (int i = minLifetime; i < maxLifetime + 1; i++)
            {
                file.Write(System.Environment.NewLine + System.Environment.NewLine);
                file.Write($"LIFETIME = {-(i + 1)}");
                file.Write(System.Environment.NewLine + System.Environment.NewLine);
                for (int j = 0; j < c_maxPermutations; j++)
                {
                    file.Write(wispList[i, j].ToCsv());
                    file.Write("\n");
                }
            }
        }
    }
}