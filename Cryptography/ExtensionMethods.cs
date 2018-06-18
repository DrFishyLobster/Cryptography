namespace Cryptography
{
    public static class ExtensionMethods
    {
        public static bool IsAlphabetic(this char Letter)
        {
            if (Letter.AlphabetPosition()>=0&&Letter.AlphabetPosition()<=25) return true;
            return false;
        }
        public static int AlphabetPosition(this char Letter)
        {
            return (int)Letter.ToString().ToUpper()[0] - 65;
        }
    }
}
