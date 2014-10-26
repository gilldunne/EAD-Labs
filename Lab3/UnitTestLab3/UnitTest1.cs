using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shape;

namespace UnitTestLab3 {

    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void Test() {           
            double expected = 200.96;
            IHasVolume shapes = new Sphere(4);
            double actual = shapes.CalcVolume();

            //foreach (IHasVolume s in shapes) {
            //    Console.WriteLine(s + " volume: " + s.CalcVolume());
            //}

            Assert.AreEqual(expected, actual);
        }
    }
}
