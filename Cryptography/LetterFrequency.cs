using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Cryptography
{
    public class LetterFrequency
    {
        public long[] Data = new long[256];
        public long Total = 0;

        #region Languages

        public enum Language { English, French, Italian };

        public static LetterFrequency EnglishAll = new LetterFrequency(new long[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 4929, 53003760, 0, 20, 52963144,
            0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 447714195, 1516180, 9822098, 28482, 43898, 7812, 53086, 6214926, 758894, 760728,
            585539, 36853, 36711320, 8890373, 24726134, 260890, 1082846, 2185017, 1066103, 827100, 714062, 742029, 641374, 604847, 813374, 571716,
            1306478, 3489231, 4458, 180044, 23170, 1569265, 20385, 5593298, 3200758, 3505353, 2303069, 3816968, 2261326, 2628065, 3990248, 9953196,
            1076922, 681999, 2643324, 3761518, 2740731, 2658217, 2958821, 181741, 2719279, 5013430, 7408703, 956534, 784685, 2775751, 255774, 1292702
            , 83807, 547462, 1885, 541429, 4134, 2780282, 2909, 158454821, 28601429, 51539967, 85114495, 256225703, 46994403, 38668897, 122798388,
            133880137, 2313875, 14022989, 79485697, 48361692, 140750044, 156077295, 34640338, 2015228, 122628006, 125516471, 183428205, 57602063,
19404300, 42445153, 3233590, 37916844, 1187793, 19881, 165548, 21075, 11832, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 27, 0, 1, 3, 42, 9, 0, 51, 0, 0, 2,
            5, 0, 1, 0, 0, 13, 0, 13, 0, 0, 14, 1872, 0, 155, 896, 6, 3, 66, 4518, 2, 3, 0, 9339, 1, 0, 6, 4, 601, 4, 20, 0, 1741, 8, 165, 204, 1,
            21, 14, 9340, 57, 216, 72, 0, 9, 573, 316, 19, 13, 3, 1748, 43, 15, 148, 8, 1, 0, 114, 27, 6, 7, 22, 0, 8, 6, 0, 49, 60, 0, 0, 86, 0, 41,
            0, 98, 0, 581, 5703, 11261, 13, 622, 183, 9297, 614, 1602, 7435, 1003, 410, 56, 1420, 1631, 337, 562, 704, 132, 544, 552, 15, 1022, 1, 26, 117, 530, 1093, 1677, 70, 841, 4 });
        public static LetterFrequency EnglishAlpha = new LetterFrequency(new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 164048119, 31802187, 55045320, 87417564, 260042671, 49255729, 41296962, 126788636, 143833333,
            3390797, 14704988, 82129021, 52123210, 143490775, 158735512, 37599159, 2196969, 125347285, 130529901, 190836908, 58558597, 20188985, 45220904, 3489364, 39209546, 1271600, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        public static LetterFrequency FrenchAll = new LetterFrequency(new long[] { 0, 0, 0, 0, 0, 0, 0, 0,
            0, 79, 10270657, 0, 0, 10270655, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 77255610,
            510354, 50726, 7207, 2529, 2064, 68233, 5009309, 133533, 134178, 106938, 4987, 7050940, 2787208,
            4891698, 58981, 174707, 347791, 169499, 126170, 107476, 115100, 98918, 98172, 133668, 94193, 413580,
            699509, 406, 75732, 514, 334866, 2564, 776881, 329047, 803033, 473209, 882662, 284948, 323704, 203642,
            808651, 424458, 46565, 916962, 806052, 437716, 415580, 617903, 168094, 444155, 616679, 471644, 227368,
            316414, 49294, 71430, 56823, 17416, 105729, 51, 105688, 185, 712474, 12, 28696633, 3445786, 11045252,
            13587499, 55578285, 4141806, 3699801, 3652314, 26984520, 1807283, 274774, 20081718, 10532844, 26341790,
            20901744, 10082329, 4226588, 25426662, 29306684, 27089496, 23164571, 6087873, 387509, 1484905, 1432419,
            646956, 1094, 24453, 1277, 87, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 3119, 14, 0, 5, 0, 0, 32, 394, 0, 33, 0, 44771, 0, 256, 1, 6, 2337, 9, 52, 11, 27,
            16, 3, 31, 0, 0, 1397, 41291, 5, 9, 0, 107, 9116, 1, 165, 2, 0, 0, 105, 1165, 2265, 21165, 686, 15, 0, 3, 302,
            108, 0, 5, 4, 28, 763, 0, 114, 14, 0, 43, 1, 32, 19, 0, 0, 10, 374952, 449, 55784, 82, 81, 0, 1056, 45526, 271566,
            1520039, 155865, 4465, 17, 359, 46015, 11169, 0, 281, 133, 482, 41553, 33, 1090, 2, 0, 34647, 126, 36459, 838, 0, 0, 8 });
        public static LetterFrequency FrenchAlpha = new LetterFrequency(new long[]{3119, 0, 0, 0, 0, 0, 0, 0, 15, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 29473514, 3774833, 11848285, 14060708, 56460947, 4426754, 4023505, 3855956, 27793171
            ,2231741, 321339, 20998680, 11338896, 26779506, 21317324, 10700232, 4394682, 25870817, 29923363, 27561140, 23391939, 6404287,
            436803, 1556335, 1489242, 664372, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0});
        public static LetterFrequency ItalianAll = new LetterFrequency(new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1015, 583670, 0, 0, 583670,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4009675, 25412, 3094, 102, 156, 85, 641, 119567, 5338, 5399, 5208, 30,
            354105, 121779, 264359, 2730, 4085, 11601, 4808, 4407, 3998, 3850, 3120, 3141, 4059, 2824, 31194, 43554, 13, 1187, 13, 22992,
            152, 39242, 13936, 38367, 27104, 49259, 17681, 24302, 4649, 49199, 1031, 818, 33875, 33280, 26153, 21795, 32846, 9185, 19516,
            37874, 24400, 10354, 16581, 1619, 4982, 2851, 1343, 2619, 7, 2530, 117, 33037, 0, 2087593, 188376, 817323, 697894, 2191987,
            218377, 358393, 249333, 1925151, 8629, 10866, 1161172, 502322, 1316739, 1769185, 504819, 96707, 1241744, 988926, 1160135, 599219,
            380837, 21781, 2931, 25816, 130317, 334, 159, 326, 505, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1092, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1147, 0, 0, 0, 0, 5, 0,
            0, 0, 0, 0, 0, 4, 5, 1, 0, 3, 1, 0, 0, 2, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1062, 2, 0, 0, 9, 0, 0, 112, 981, 915, 0,
            86, 1427, 5, 0, 434, 0, 0, 978, 35, 3, 0, 2, 0, 0, 1137, 0, 0, 56, 0, 0, 0 });
        public static LetterFrequency ItalianAlpha = new LetterFrequency(new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2126835, 202312, 855690, 724998, 2241246, 236058,
        382695, 253982, 1974350, 9660, 11684, 1195047, 535602, 1342892, 1790980, 537665, 105892, 1261260, 1026800, 1184535,
        609573, 397418, 23400, 7913, 28667, 131660, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
        public static LetterFrequency[] AllLanguages = new LetterFrequency[] { EnglishAll, FrenchAll, ItalianAll };
        public static LetterFrequency[] AlphaLanguages = new LetterFrequency[] { EnglishAlpha, FrenchAlpha, ItalianAlpha };
        public static LetterFrequency Guten = new LetterFrequency();

        #endregion Languages

        public LetterFrequency(long[] Data)
        {
            long count = 0;
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
            places %= NonAlphabet ? 256 : 26; //To Correct and place in right range
            places += NonAlphabet ? 256 : 26;
            places %= NonAlphabet ? 256 : 26;
            long[] TempData = new long[256];
            if (NonAlphabet)
            {
                for (int pos = 0; pos < 256; pos++)
                {
                    TempData[(pos + places) % 256] = this.Data[pos];
                }
            }
            else
            {
                for (int pos = 0; pos < 26; pos++)
                {
                    TempData[65 + (pos + places) % 26] = this.Data[65 + pos];
                }
            }
            return new LetterFrequency(TempData);
        }
        public double Compare(LetterFrequency Other, Mode mode = Mode.Alphabet)
        {
            double difference = 0;
            for (int i = (mode == Mode.Alphabet ? 65 : 0); i < (mode == Mode.Alphabet ? 256 : 91); i++)
            {
                difference += Math.Abs((double)Other.Data[i] / Other.Total - (double)Data[i] / Total);
            }
            difference /= 2;
            return 1 - difference;
        }
        public void Add(char character)
        {
            if ((int)character <= 255) { Total++; Data[(int)character]++; }
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

        #region Gutenberg

        public static void GenerateFromGutenberg(string path)
        {
            foreach (var item in Directory.GetDirectories(path))
            {
                GenerateFromGutenberg(item);
            }
            try
            {
                if (Directory.GetFiles(path).Length != 0)
                {
                    string item = Directory.GetFiles(path)[0];
                    ZipArchive Archive = ZipFile.OpenRead(item);

                    foreach (var entry in Archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                        {
                            // Gets the full path to ensure that relative segments are removed.
                            string destinationPath = Path.GetFullPath(Path.Combine(path, entry.FullName));
                            // Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                            // are case-insensitive.

                            entry.ExtractToFile(destinationPath);
                            string text = File.ReadAllText(destinationPath);
                            foreach (var letter in text)
                            {
                                if ((int)letter >= 256) continue;
                                AddToStatic(letter);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public static void ConvertGutenberg(string output)
        {
            long[] All = new long[256];
            long[] Alpha = new long[256];
            var temp = output.Split(',');
            for (int pos = 0; pos < 256; pos++)
            {
                All[pos] = Int64.Parse(temp[pos]);
                if (((char)pos).IsAlphabetic())
                {
                    Alpha[((char)pos).AlphabetPosition() + 65] += Int64.Parse(temp[pos]);
                }
            }

            Console.Write("new long[]{");
            foreach (var item in All)
            {
                Console.Write(item);
                Console.Write(',');
            }
            Console.WriteLine("}");
            Console.Write("new long[]{");
            foreach (var item in Alpha)
            {
                Console.Write(item);
                Console.Write(',');
            }
            Console.WriteLine("}");
        }
        public static void AddToStatic(char letter)
        {
            Guten.Data[(int)letter]++;
        }

        #endregion Gutenberg

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