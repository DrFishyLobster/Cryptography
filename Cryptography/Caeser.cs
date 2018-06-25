namespace Cryptography
{
    public enum Mode { Alphabet, CharacterUTF8 }

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
                    if (!character.IsAlphabetic()) { CipherText += character; continue; }
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
            double bestScore = -1;
            Language language = Language.English;
            LetterFrequency frequency = LetterFrequency.GenerateFrequency(CipherText);

            for (int keyAttempt = 0; keyAttempt < (mode == Mode.Alphabet ? 26 : 256); keyAttempt++)
            {
                LetterFrequency tempFrequency = frequency.Shift(-keyAttempt, mode != Mode.Alphabet);
                double tempScore = -1;
                double tempID = -1;
                if (mode == Mode.CharacterUTF8)
                {
                    for (int ID = 0; ID < LetterFrequency.AllLanguages.Length; ID++)
                    {
                        double langScore = tempFrequency.Compare(LetterFrequency.AllLanguages[ID]);
                        if (langScore > tempScore)
                        {
                            tempScore = langScore;
                            tempID = ID;
                        }
                    }
                }
                else
                {
                    for (int ID = 0; ID < LetterFrequency.AlphaLanguages.Length; ID++)
                    {
                        double langScore = tempFrequency.Compare(LetterFrequency.AlphaLanguages[ID]);
                        if (langScore > tempScore)
                        {
                            tempScore = langScore;
                            tempID = ID;
                        }
                    }
                }
                if (tempScore > bestScore)
                {
                    bestScore = tempScore;
                    language = (Language)tempID;
                    bestKey = keyAttempt;
                }
            }

            string output = "The best language of choice was: " + language.ToString() + "\n";
            output += "The best key of choice was " + bestKey + " with a score of " + bestScore + "\nDecoded message is:\n";
            output += Decrypt(CipherText, bestKey, mode);
            return output;
        }
    }
}