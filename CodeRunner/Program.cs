using Cryptography;
using System;

namespace CodeRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(CaeserCipher.Solve("IFMMP"));
        }
    }
}