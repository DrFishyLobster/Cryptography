using Cryptography;
using System;
using System.Collections.Generic;

namespace CodeRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine(LetterFrequency.GenerateFromBooks(new List<string>()
            //{
            //    ".../.../.../Assets/PrideAndPrejudice.txt",
            //    ".../.../.../Assets/AliceInWonderland.txt",
            //    ".../.../.../Assets/MobyDick.txt"
            //}
            //));
            Console.WriteLine(CaeserCipher.Solve(Console.ReadLine(),Mode.CharacterUTF8));
        }
    }
}