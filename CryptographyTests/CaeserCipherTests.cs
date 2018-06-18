using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cryptography.Tests
{
    [TestClass()]
    public class CaeserCipherTests
    {
        [TestMethod()]
        public void CaeserCipherEncryptTest()
        {
            string Test1 = "Hello, today is a nice day.";
            Assert.AreEqual("HELLOTODAYISANICEDAY", CaeserCipher.Encrypt(Test1, 0));
            Assert.AreEqual("IFMMPUPEBZJTBOJDFEBZ", CaeserCipher.Encrypt(Test1, 1));
        }

        [TestMethod()]
        public void CaeserCipherDecryptTest()
        {
            string Test1 = "Hello, today is a nice day.";
            Assert.AreEqual("HELLOTODAYISANICEDAY", CaeserCipher.Decrypt(Test1, 0));
            Assert.AreEqual("HELLOTODAYISANICEDAY", CaeserCipher.Decrypt("IFMMPUPEBZJTBOJDFEBZ", 1));
        }
    }
}