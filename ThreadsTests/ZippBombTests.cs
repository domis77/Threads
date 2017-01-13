using Microsoft.VisualStudio.TestTools.UnitTesting;
using Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Threads.Tests
{
    [TestClass()]
    public class ZippBombTests
    {
        [TestMethod()]
        public void ZippBombTest()
        {
            int threadsNumber = 2;
            string path = "C:\\";
            object[] args = new object[] { new Thread[threadsNumber] };

            ZippBomb zippBombTest = new ZippBomb(threadsNumber, path);
            PrivateObject privateObj = new PrivateObject(zippBombTest);

            Assert.AreEqual(path,privateObj.GetFieldOrProperty("filePath"));
        }

        [TestMethod()]
        public void makeTheBombTest()
        {
            int threadsNumber = 2;
            string path = "C:\\";
            object[] args = new object[] { new Thread[threadsNumber] };

            ZippBomb zippBombTest = new ZippBomb(threadsNumber, path);
            PrivateObject privateObj = new PrivateObject(zippBombTest);

            privateObj.Invoke("makeTheBomb", args);

            Thread[] threadsList = (Thread[])args[0];


            for(int i=0; i< threadsList.Length; i++)
            {
                Assert.IsNotNull(threadsList[i]);
                Assert.IsInstanceOfType(threadsList[i], typeof(Thread));
            }
        }
    }
}