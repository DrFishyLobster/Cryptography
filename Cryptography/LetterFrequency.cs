using System;
using System.Collections.Generic;
using System.IO;

namespace Cryptography
{
    public class LetterFrequency
    {
        private static char[] Characters = new char[39]
        {
            'A','B','C','D','E','F','G','H','I','J',
            'K','L','M','N','O','P','Q','R','S','T',
            'U','V','W','X','Y','Z',' ','.',',','?',
            '!',':','\'','"','-','(',')','0','~'
        };
        public static LetterFrequency EnglishLetterFrequency = new LetterFrequency(new int[] {
            131734, 28319, 40384, 67165, 205924, 36028, 34673,
            106238, 114282, 2381, 12855, 70649, 41286, 113556, 121648,
            28537, 2439, 93668, 106283, 150259, 46690, 15533, 38065, 2107,
            32847, 1656, 339574, 15793, 31233, 1671, 2719, 633, 3693, 0
            , 4598, 345, 350, 1608, 98331 });

        private int[] Data = new int[39];
        private int Total = 0;

        public LetterFrequency(int[] Data)
        {
            int count = 0;
            foreach (var item in Data)
            {
                count += item;
            }
            this.Data = Data;
            Total = count;
        }
        public LetterFrequency()
        {
        }

        public LetterFrequency Shift(int places, bool NonAlphabet)
        {
            places = ((places % (NonAlphabet ? 39 : 26)) + (NonAlphabet ? 39 : 26)) % (NonAlphabet ? 39 : 26);
            int[] TempData = new int[39];
            for (int pos = 0; pos < (NonAlphabet ? 39 : 26); pos++)
            {
                TempData[(pos + places) % (NonAlphabet ? 39 : 26)] = Data[pos];
            }
            if (!NonAlphabet)
            {
                for (int pos = 26; pos < 39; pos++)
                {
                    TempData[pos] = Data[pos];
                }
            }
            return new LetterFrequency(TempData);
            return new LetterFrequency(TempData);
        }
        public void Add(char Letter)
        {
            if (Letter.IsAlphabetic())
            {
                Total++;
                Data[Letter.AlphabetPosition()]++;
            }
            else
            {
                switch (Letter)
                {
                    case ' ':
                        Data[26]++;
                        break;

                    case '.':
                        Data[27]++;
                        break;

                    case ',':
                        Data[28]++;
                        break;

                    case '?':
                        Data[29]++;
                        break;

                    case '!':
                        Data[30]++;
                        break;

                    case ':':
                        Data[31]++;
                        break;

                    case '\'':
                        Data[32]++;
                        break;

                    case '"':
                        Data[33]++;
                        break;

                    case '-':
                        Data[34]++;
                        break;

                    case '(':
                        Data[35]++;
                        break;

                    case ')':
                        Data[36]++;
                        break;

                    default:
                        if (Letter.IsNumber()) Data[37]++;
                        else Data[38]++;
                        break;
                }
                Total++;
            }
        }
        public float Compare(LetterFrequency other, bool NonAlphabet)
        {
            float Difference = 0;
            for (int ch = 0; ch < (NonAlphabet ? 39 : 26); ch++)
            {
                Difference += Math.Abs(other.Data[ch] / (float)other.Total - Data[ch] / (float)Total);
            }
            Difference /= 2;
            return 1 - Difference;
        }

        public static LetterFrequency GenerateFromBooks(List<string> locations)
        {
            LetterFrequency Output = new LetterFrequency();
            foreach (var book in locations)
            {
                string temp = File.ReadAllText(book);
                foreach (var character in temp)
                {
                    Output.Add(character);
                }
            }
            return Output;
        }
        public static LetterFrequency GenerateFrequency(string Data)
        {
            LetterFrequency output = new LetterFrequency();
            foreach (var character in Data)
            {
                output.Add(character);
            }
            return output;
        }

        public override string ToString()
        {
            string output = "";
            foreach (var letter in Data)
            {
                output += letter.ToString() + ",";
            }
            return output;
        }
    }
}