using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest : TestBase
    {
        private const string BAD_FILE_NAME = @"C:\lenaTest\notfound.txt";

        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            //initialize for all tests in a class
            tc.WriteLine("In Class initialize() method");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            //clean after all tests in class
        }

        [TestMethod]
        [Description("check to see if file is exist")]
        [Owner("Lena")]
        [Priority(1)]
        [TestCategory("No exception")]

        public void FileNameDoesExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;
            //Act
            //TestContext.WriteLine(@"Checking file: C:\lenaTest\UnitTest.txt");//hard coding
            SetGoodFileNAme();
            if (!string.IsNullOrEmpty(_GoodFileName))
            {
                //create the good file
                File.AppendAllText(_GoodFileName,"some text");
            }
            TestContext.WriteLine("Checking file: " + _GoodFileName);//dynamic

            fromCall = fp.FileExists(_GoodFileName);

            //Delete file
            if (File.Exists(_GoodFileName))
                File.Delete(_GoodFileName);

            //Assert
            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        public void FileNameDoesNotExist()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            bool fromCall;
            //Act
            TestContext.WriteLine("Checking file:" + BAD_FILE_NAME);
            fromCall = fp.FileExists(BAD_FILE_NAME);
            //Assert
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileNameNullOrEmpty_UsingAttribute()
        {
            //Arrange
            FileProcess fp = new FileProcess();
            //Act
            TestContext.WriteLine("Checking for a null file:");

            fp.FileExists("");
        }

        [TestMethod]
        public void FileNameNullOrEmpty_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();
            try
            {
                TestContext.WriteLine("Checking for a null file:");

                fp.FileExists("");
            }
            catch(ArgumentNullException)
            {
                //test was success
                //if i pass "" to function above.
                return;
            }
            //fail the test
            //if i pass "something" to function above
            //this is message to be showen if the test is failed
            Assert.Fail("call to fileExist() didn't throw an ArgumentNullException");
        }

    }
}