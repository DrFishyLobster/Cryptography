using Cryptography;
using System;

namespace CodeRunner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Gutenberg

            //LetterFrequency.GenerateFromGutenberg("...\\...\\...\\Assets");
            //Console.WriteLine(LetterFrequency.Guten);
            //LetterFrequency.ConvertGutenberg("0,0,0,0,0,0,0,0,0,79,10270657,0,0,10270655,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,77255610,510354,50726,7207,2529,2064,68233,5009309,133533,134178,106938,4987,7050940,2787208,4891698,58981,174707,347791,169499,126170,107476,115100,98918,98172,133668,94193,413580,699509,406,75732,514,334866,2564,776881,329047,803033,473209,882662,284948,323704,203642,808651,424458,46565,916962,806052,437716,415580,617903,168094,444155,616679,471644,227368,316414,49294,71430,56823,17416,105729,51,105688,185,712474,12,28696633,3445786,11045252,13587499,55578285,4141806,3699801,3652314,26984520,1807283,274774,20081718,10532844,26341790,20901744,10082329,4226588,25426662,29306684,27089496,23164571,6087873,387509,1484905,1432419,646956,1094,24453,1277,87,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3119,14,0,5,0,0,32,394,0,33,0,44771,0,256,1,6,2337,9,52,11,27,16,3,31,0,0,1397,41291,5,9,0,107,9116,1,165,2,0,0,105,1165,2265,21165,686,15,0,3,302,108,0,5,4,28,763,0,114,14,0,43,1,32,19,0,0,10,374952,449,55784,82,81,0,1056,45526,271566,1520039,155865,4465,17,359,46015,11169,0,281,133,482,41553,33,1090,2,0,34647,126,36459,838,0,0,8");
            //for (int l = 65; l < 65 + 26; l++)
            //{
            //    Console.WriteLine((char)l + " - " + 100 * (double)LetterFrequency.EnglishAlpha.Data[l] / LetterFrequency.EnglishAlpha.Total + "-" + 100 * (double)LetterFrequency.FrenchAlpha.Data[l] / LetterFrequency.FrenchAlpha.Total);
            //}

            #endregion Gutenberg
            string text = @"And did those feet in ancient time
Walk upon England's mountains green?
And was the holy Lamb of God
On England's pleasant pastures seen?
And did the countenance divine
Shine forth upon our clouded hills?
And was Jerusalem builded here
Among those dark Satanic Mills?

Bring me my bow of burning gold!
Bring me my arrows of desire!
Bring me my spear! O clouds, unfold!
Bring me my chariot of fire!
I will not cease from mental fight
Nor shall my sword sleep in my hand
Till we have built Jerusalem
In England's green and pleasant Land";
            string Cipher = @"BOE EJE UIPTF GFFU JO BODJFOU UJNF
XBML VQPO FOHMBOE'T NPVOUBJOT HSFFO?
BOE XBT UIF IPMZ MBNC PG HPE
PO FOHMBOE'T QMFBTBOU QBTUVSFT TFFO?
BOE EJE UIF DPVOUFOBODF EJWJOF
TIJOF GPSUI VQPO PVS DMPVEFE IJMMT?
BOE XBT KFSVTBMFN CVJMEFE IFSF
BNPOH UIPTF EBSL TBUBOJD NJMMT?

CSJOH NF NZ CPX PG CVSOJOH HPME!
CSJOH NF NZ BSSPXT PG EFTJSF!
CSJOH NF NZ TQFBS! P DMPVET, VOGPME!
CSJOH NF NZ DIBSJPU PG GJSF!
J XJMM OPU DFBTF GSPN NFOUBM GJHIU
OPS TIBMM NZ TXPSE TMFFQ JO NZ IBOE
UJMM XF IBWF CVJMU KFSVTBMFN
JO FOHMBOE'T HSFFO BOE QMFBTBOU MBOE";
            Console.WriteLine(CaeserCipher.Encrypt(text,1,Mode.Alphabet));
            Console.WriteLine(text.LanguageDetection());
            Console.WriteLine(CaeserCipher.Solve(Cipher, Mode.Alphabet));
        }
    }
}