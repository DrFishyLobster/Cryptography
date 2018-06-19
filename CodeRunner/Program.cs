using Cryptography;
using System;

namespace CodeRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(CaeserCipher.Solve(CaeserCipher.Encrypt("Zambia is my country,. I love it", 10, Mode.Alphabet), Mode.CharacterUTF8));
        }
    }
}