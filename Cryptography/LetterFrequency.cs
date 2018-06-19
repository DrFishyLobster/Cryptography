using System;

namespace Cryptography
{
    public class LetterFrequency
    {
        public static LetterFrequency EnglishLetterFrequency = new LetterFrequency(new int[] { 8167, 1492, 2782, 4253,
                12702, 2228, 2015, 6094, 6966, 153, 772, 4025, 2406,
                6749, 7507,1929, 95, 5987, 6327, 9056, 2758, 978, 2360,
                150, 1974, 74 });

        private int[] Data = new int[26];
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

        public LetterFrequency Shift(int places)
        {
            places = ((places % 26) + 26) % 26;
            int[] TempData = new int[26];
            for (int pos = 0; pos < 26; pos++)
            {
                TempData[(pos + places) % 26] = Data[pos];
            }
            return new LetterFrequency(TempData);
        }
        public void Add(char Letter)
        {
            if (Letter.IsAlphabetic())
            {
                Total++;
                Data[Letter.AlphabetPosition()]++;
            }
        }
        public float Compare(LetterFrequency other)
        {
            float Difference = 0;
            for (int ch = 0; ch < 26; ch++)
            {
                Difference += Math.Abs(other.Data[ch] / (float)other.Total - Data[ch] / (float)Total);
            }
            Difference /= 2;
            return 1 - Difference;
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
    }
}