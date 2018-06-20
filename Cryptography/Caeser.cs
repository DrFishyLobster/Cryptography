namespace Cryptography
{
    public enum Mode { Alphabet, CharacterUTF8, }

    public static class CaeserCipher
    {
        public static string Encrypt(string PlainText, int Key, Mode mode = Mode.Alphabet)
        {
            if (mode == Mode.Alphabet) PlainText = PlainText.ToUpper();
            string CipherText = "";
            foreach (var character in PlainText)
            {
                if (mode == Mode.Alphabet)
                {
                    if (!character.IsAlphabetic()) continue;
                    int positionInAlphabet = (int)character - 65;
                    int shifted = (positionInAlphabet + Key % 26 + 26) % 26;
                    CipherText += (char)(shifted + 65);
                }
                else
                {
                    CipherText += (char)(((int)(character) + Key) % 256);
                }
            }
            return CipherText;
        }
        public static string Decrypt(string CipherText, int Key, Mode mode = Mode.Alphabet)
        {
            return Encrypt(CipherText, -Key, mode);
        }
        public static string Solve(string CipherText, Mode mode = Mode.Alphabet)
        {
            int bestKey = 0;
            float score = 0;
            LetterFrequency FrequencyOrig = LetterFrequency.GenerateFrequency(CipherText);
            if (mode == Mode.Alphabet)
            {
                for (int key = 0; key <= 26; key++)
                {
                    LetterFrequency TestFrequency = FrequencyOrig.Shift(key);
                    float tempScore = TestFrequency.Compare(LetterFrequency.EnglishLetterFrequency);
                    if (tempScore > score)
                    {
                        bestKey = key;
                        score = tempScore;
                    }
                }
            }
            else
            {
                for (int key = 0; key <= 256; key++)
                {
                    LetterFrequency TestFrequency = LetterFrequency.GenerateFrequency(Decrypt(CipherText, key, Mode.CharacterUTF8));
                    float tempScore = TestFrequency.Compare(LetterFrequency.EnglishLetterFrequency);
                    if (tempScore > score)
                    {
                        bestKey = key;
                        score = tempScore;
                    }
                }
            }
            return Decrypt(CipherText, bestKey, mode);
        }
    }
}