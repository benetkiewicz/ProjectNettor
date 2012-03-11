namespace Tests
{
    using System;
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DateCalculationTests
    {
        [TestMethod]
        public void UpRoundingShouldWorkFineTest()
        {
            var calculator = new DateCalculator();
            var testTime = new DateTime(2000, 10, 10, 12, 22, 29);

            DateTime result = calculator.CalculateEndTime(testTime);

            var expected = new DateTime(2000, 10, 10, 12, 15, 0);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UpRoundingShouldWorkFineTest2()
        {
            var calculator = new DateCalculator();
            var testTime = new DateTime(2000, 10, 10, 12, 58, 29);

            DateTime result = calculator.CalculateEndTime(testTime);

            var expected = new DateTime(2000, 10, 10, 13, 00, 0);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DownRoundingShouldWorkFineTest()
        {
            var calculator = new DateCalculator();
            var testTime = new DateTime(2000, 10, 10, 12, 23, 29);

            DateTime result = calculator.CalculateEndTime(testTime);

            var expected = new DateTime(2000, 10, 10, 12, 30, 0);
            Assert.AreEqual(expected, result);
        }
    }
}