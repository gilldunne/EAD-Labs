using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            Assert.AreEqual(Calculator.Divide(10, 2), 5);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod2() {
            Calculator.Divide(10, 0);
          
        }
    }
}
