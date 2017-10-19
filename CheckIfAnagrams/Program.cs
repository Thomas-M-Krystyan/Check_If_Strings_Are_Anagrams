using System;

namespace CheckIfAnagrams
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("First algorithm");
            Console.WriteLine(StringComparison.CheckIfAnagrams1("Armageddon!", "dnarde!mAog"));

            Console.WriteLine("\nSecond algorithm");
            Console.WriteLine(StringComparison.CheckIfAnagrams2("Armageddon!", "dnarde!mAog"));

            Console.ReadLine();
        }
    }
}
