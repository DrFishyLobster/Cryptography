using System;

namespace Cryptography
{
    public static class ExtensionMethods
    {
        public static bool IsAlphabetic(this char Letter)
        {
            if (Letter.AlphabetPosition() >= 0 && Letter.AlphabetPosition() <= 25) return true;
            return false;
        }
        public static int AlphabetPosition(this char Letter)
        {
            return (int)Letter.ToString().ToUpper()[0] - 65;
        }
        public static bool IsUpper(this char Letter)
        {
            if (!Letter.IsAlphabetic()) throw new FormatException("Character is not a letter.");
            return Letter.ToString().ToUpper()[0] == Letter;
        }
        public static bool IsLower(this char Letter) => IsUpper(Letter);
        public static bool IsNumber(this char Letter)
        {
            if ((int)Letter >= 48 && (int)Letter <= 57) return true;
            return false;
        }
    }
}