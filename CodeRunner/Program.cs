using Cryptography;
using System;
namespace CodeRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LetterFrequency.GenerateFrequency("A Waterloo Medal was designed by sculptor Benedetto Pistrucci. Commemorating the Battle of Waterloo (18 June 1815), the medal was commissioned by the British Government in 1819 on the instructions of George IV while Prince Regent; copies were to be presented to the victorious generals and to leaders of Britain's allies. The Prince Regent and William Wellesley-Pole, Master of the Mint, had been impressed by Pistrucci's models, and gave him the commission. Pistrucci fell from grace at the Royal Mint in 1823 by insisting on his own designs and refusing to copy another designer's work, and he likely concluded he would be sacked when the medal was finished. He delayed completion until 1849, when he submitted the matrices to the Mint. As most of the intended recipients had died by then, and relations with France had improved, the medals were never struck, though modern-day editions have been made for sale to collectors. Pistrucci's designs have been greatly praised by numismatic").Compare(LetterFrequency.EnglishLetterFrequency));
        }
    }
}
