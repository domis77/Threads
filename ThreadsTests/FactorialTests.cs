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
    public class FactorialTests
    {
        object factorialNumber = 5;
        Double expectedResult = 120;

        [TestMethod()]
        public void iterationDelegateTest()
        {   
            Factorial factorialTest = new Factorial();
            factorialTest.iterationDelegate(factorialNumber);

            Assert.IsNotNull(factorialTest.resultIteration);
            Assert.IsInstanceOfType(factorialTest.resultIteration, typeof(String));

            Assert.IsNotNull(factorialTest.calculationTimeIteration);
            Assert.IsInstanceOfType(factorialTest.calculationTimeIteration, typeof(String));
        }

        [TestMethod()]
        public void iterationTest()
        {
            Factorial factorialTest = new Factorial();
            PrivateObject privateObj = new PrivateObject(factorialTest);

            var result = privateObj.Invoke("iteration", factorialNumber);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Double));
            Assert.AreEqual(result, expectedResult);
        }


        [TestMethod()]
        public void recursionDelegateTest()
        {
            Factorial factorialTest = new Factorial();
            factorialTest.recursionDelegate(factorialNumber);

            Assert.IsNotNull(factorialTest.resultRecursion);
            Assert.IsInstanceOfType(factorialTest.resultRecursion, typeof(String));

            Assert.IsNotNull(factorialTest.calculationTimeRecursion);
            Assert.IsInstanceOfType(factorialTest.calculationTimeRecursion, typeof(String));
        }

        [TestMethod()]
        public void recursionTest()
        {
            Factorial factorialTest = new Factorial();
            PrivateObject privateObj = new PrivateObject(factorialTest);

            var result = privateObj.Invoke("recursion", factorialNumber);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Double));
            Assert.AreEqual(result, expectedResult);
        }
    }
}