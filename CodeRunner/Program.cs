using Cryptography;
using System;

namespace CodeRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(CaeserCipher.Solve("QEB NRFZH YOLTK CLU GRJMP LSBO QEB IXWV ALD", Mode.Alphabet));
        }
    }
}