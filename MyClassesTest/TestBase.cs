using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassesTest
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }
        protected string _GoodFileName;

        protected void SetGoodFileNAme()
        {
            _GoodFileName = TestContext.Properties["GoodFileNAme"].ToString();
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("AppPath", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
            //this is generic, it will work at any machine (dynamic)
        }

    }
}
