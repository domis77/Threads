using Microsoft.VisualStudio.TestTools.UnitTesting;
using Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;




namespace Threads.Tests
{
    [TestClass()]
    public class Exercise2Tests
    {
        [TestMethod()]
        public void IterationFactorialTest()
        {
            Exercise2 exercise2Test = new Exercise2();
            PrivateObject privateObj = new PrivateObject(exercise2Test);

            privateObj.Invoke("IterationFactorial", null);

            Thread IterationThread = (Thread)privateObj.GetFieldOrProperty("IterationThread");

            Assert.IsNotNull(IterationThread);
            Assert.IsInstanceOfType(IterationThread, typeof(Thread));
            Assert.AreEqual(IterationThread.Name, "IterationFactorial");
        }

        [TestMethod()]
        public void RecursionFactorialTest()
        {
            Exercise2 exercise2Test = new Exercise2();
            PrivateObject privateObj = new PrivateObject(exercise2Test);

            privateObj.Invoke("RecursionFactorial", null);

            Thread RecursionThread = (Thread)privateObj.GetFieldOrProperty("RecursionThread");

            Assert.IsNotNull(RecursionThread);
            Assert.IsInstanceOfType(RecursionThread, typeof(Thread));
            Assert.AreEqual(RecursionThread.Name, "RecursionFactorial");
        }
    }
}