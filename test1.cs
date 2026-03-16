using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1Tests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void getSideOfCube_cubedRootOfVolume()
        {
            double result = Lab1.getSideOfCube(27);
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void isSumUneven_booleanValue()
        {
            bool result = Lab1.isSumUneven(23);
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void IsInTriangle_PointInside()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            Lab1.isInTriangle(0, 0);

            string result = sw.ToString().Trim();
            Assert.AreEqual("On the bounds", result);
        }

        [TestMethod]
        public void get_date_dateNDaysAgo()
        {
            DateTime result = Lab1.get_date(2);
            DateTime expected = DateTime.Now.AddDays(-2);
            Assert.IsTrue(Math.Abs((result - expected).TotalSeconds) < 1);
        }

        [TestMethod]
        public void get_square_sum_sumOfSquares()
        {
            int result = Lab1.get_square_sum(2, 3);
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void get_result_calculateExpression()
        {
            double result = Lab1.get_result(2, 3);
            double expected = 5 + 3 / (3 * 3 + 1.0) + (2 - 3) / (2 + 3.0);

            Assert.AreEqual(expected, result, 0.0001);
        }
    }
}
