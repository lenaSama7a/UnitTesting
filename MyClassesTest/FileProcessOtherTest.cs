using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
namespace MyClassesTest
{
    [TestClass]
    public class FileProcessOtherTest : TestBase
    {
        [TestMethod]
        public void FileNAmeDoesExistMessagge()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(_GoodFileName);
            //Assert.IsFalse(fromCall, "File"+_GoodFileName + "Does not Exist");
            Assert.IsFalse(fromCall, "File { 0 } Does not Exist", _GoodFileName);

        }
        [TestMethod]
        public void AreEqualTest()
        {
            string str1 = "Lena";
            string str2 = "lena";
            Assert.AreEqual(str1, str2);
        }
    }
}