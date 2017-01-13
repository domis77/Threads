using Microsoft.VisualStudio.TestTools.UnitTesting;
using Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Tests
{
    [TestClass()]
    public class BinaryFileTests
    {
        [TestMethod()]
        public void BinaryFileTest()
        {
            string path = "C:\\";

            BinaryFile binaryFileTest = new BinaryFile(path);
            PrivateObject privateObj = new PrivateObject(binaryFileTest);

            Assert.AreEqual(path, privateObj.GetFieldOrProperty("filePath"));
            Assert.IsNotNull(privateObj.GetFieldOrProperty("rand"));
            Assert.IsInstanceOfType(privateObj.GetFieldOrProperty("rand"), typeof(Random));
        }

        [TestMethod()]
        public void createFileTest()
        {
        }
    }
}