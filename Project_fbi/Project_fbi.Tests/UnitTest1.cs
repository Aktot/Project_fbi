using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_fbi.Helpers;
using System.Drawing;
namespace Project_fbi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        Encryptor encrypt = new Encryptor();

        [TestMethod]
        public void TestingCLSBMethod1()
        {
            int[] resMas = new int[3] { 202, 196, 206 };
            int[] getedMas = encrypt.ClearLeastSugnificantBitColor(Color.FromArgb(202, 245, 206));

            Assert.AreNotEqual(resMas, getedMas);                      
        }
        [TestMethod]
        public void TestingEncryptedMethod()
        {
            Bitmap resPicture = new Bitmap("..\\..\\Content\\resImage.png");
            Bitmap actualPicture = new Bitmap("..\\..\\Content\\zytadel.png");
            string text = "Hello world!";
            bool res = encrypt.compare(resPicture, encrypt.Encrypt(text, actualPicture));
            Assert.AreEqual(true,res);
        }

        [TestMethod]
        public void TestingDecryptMethod()
        {
            Bitmap resPicture = new Bitmap("..\\..\\Content\\resImage.png");

            string restext = "Hello world!";
            string gettedText = encrypt.Decrypt(resPicture);

            Assert.AreEqual(restext, gettedText,"Text should be equal");
        }
    }
}
