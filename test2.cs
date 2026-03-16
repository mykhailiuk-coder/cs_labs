using MathNet.Numerics.LinearAlgebra;
namespace lab2.test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void getNumberOutOfRange_intCountOfNumbersOutOfRange()
        {
            int[] arr = { 1, 5, 10, 15, 20 };
            int low = 5;
            int high = 15;
            int expected = 2;
            int actual = Lab2.getNumberOutOfRange(arr, low, high);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void getMinimum_intMinimumValueInArray()
        {
            int[] arr = { 5, 3, 8, 1, 4 };
            int size = arr.Length;
            int expected = 1;
            int actual = Lab2.getMinimum(arr, size);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void getMatrixToPower_MatrixRaisedToPower()
        {
            var M = Matrix<double>.Build.DenseOfArray(new double[,] { { 1, 2 }, { 3, 4 } });
            int power = 2;
            var expected = Matrix<double>.Build.DenseOfArray(new double[,] { { 7, 10 }, { 15, 22 } });
            var actual = Lab2.getMatrixToPower(2, M, power);
            Assert.AreEqual(actual, expected);
        }
    }
}
