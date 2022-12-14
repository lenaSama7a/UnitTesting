using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    [TestClass]
    public class MyClassesTestInitialization
    {
        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext tc)
        {
            //initialize for all tests within an assembly 
            tc.WriteLine("In Assembly initialize() method");
        }

        [AssemblyCleanup()] 
        public static void AssemblyCleanup()
        {
            //clean up after all tests in an assembly
        }

    }
}
