namespace Cryptography
{
    public enum Mode { Alphabet, CharacterUTF8, }
    public static class CaeserCipher
    {
        public static string Encrypt(string PlainText, int Key, Mode mode = Mode.Alphabet)
        {
            PlainText = PlainText.ToUpper();
            string CipherText = "";
            foreach (var character in PlainText)
            {
                if (mode == Mode.Alphabet)
                {
                    if (!character.IsAlphabetic()) continue;
                    int positionInAlphabet = (int)character - 65;
                    int shifted = (positionInAlphabet + Key) % 26;
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
            return null;
        }
    }
}
