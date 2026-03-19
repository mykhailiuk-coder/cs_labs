using MathNet.Numerics.LinearAlgebra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestMethod]
        public void GetSumOfElementsInRange_SumOfElementsInSpecifiedColumnRange()
        {
            int[][] matrix = new int[][]
            {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 6, 7, 8 },
                new int[] { 9, 10, 11, 12 }
            };
            int n = matrix.Length;
            int m = matrix[0].Length;
            int k1 = 1;
            int k2 = 2;
            int[] expected = new int[] { 5, 13, 21 };
            int[] actual = Lab2.GetSumOfElementsInRange(matrix, n, m, k1, k2);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
