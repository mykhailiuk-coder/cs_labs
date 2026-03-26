using MathNet.Numerics.LinearAlgebra;
using System;
using System.Linq;

public class Lab2
{
    public static int getNumberOutOfRange(int[] arr, int low, int high)
    {
        int count = 0;
        foreach (int num in arr)
        {
            if (num < low || num > high)
            {
                count++;
            }
        }
        return count;
    }
    public static int getMinimum(int[] arr, int size)
    {
        if (size == 0 || arr.Length == 0)
        {
            throw new ArgumentException("Array cannot be empty.");
        }
        int min = arr[0];
        for (int i = 0; i < size; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        return min;
    }

    public static Matrix<double> getMatrixToPower(int n, Matrix<double> M, int power)
    {
        for (int i = 1; i < power; i++)
        {
            M = M * M;
        }
        return M;
    }

    public static int[] GetSumOfElementsInRange(int[][] matrix, int k1, int k2)
    {
        if (matrix == null) throw new ArgumentNullException(nameof(matrix));

        if (k1 < 0 || k1 > k2)
        {
            throw new ArgumentException($"Некоректний діапазон: k1={k1}, k2={k2}.");
        }

        int[] sums = new int[matrix.Length];

        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i] == null) continue;
            int start = k1;
            int end = Math.Min(k2, matrix[i].Length - 1);

            for (int j = start; j <= end; j++)
            {
                sums[i] += matrix[i][j];
            }
        }
        return sums;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Input task: ");
            int taskNumber = int.Parse(Console.ReadLine()!);
            switch (taskNumber)
            {
                case 1:
                    int[] arr = { 1, 5, 10, 15, 20 };
                    int low = 5;
                    int high = 15;
                    int result = Lab2.getNumberOutOfRange(arr, low, high);
                    Console.WriteLine($"Number of elements out of range: {result}");
                    break;
                case 2:
                    Console.WriteLine("Input size of array: ");
                    int size = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Input array: ");
                    int[] arr2 = Console.ReadLine()!.Trim().Split(' ').Select(int.Parse).ToArray();
                    float min = Lab2.getMinimum(arr2, size);
                    Console.WriteLine($"Minimum element in the array: {min}");
                    break;
                case 3:
                    Console.Write("Input n: ");
                    int n = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Input matrix(n x n): ");
                    var matrix = Matrix<double>.Build.Dense(n, n);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write($"matrix[{i},{j}]: ");
                            matrix[i, j] = int.Parse(Console.ReadLine()!);
                        }
                    }
                    Console.Write("Input power: ");
                    int power = int.Parse(Console.ReadLine()!);
                    var resultMatrix = Lab2.getMatrixToPower(n, matrix, power);
                    Console.WriteLine($"Matrix to the power of {power}: ");
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(resultMatrix[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 4:
                    Console.WriteLine("Input n: ");
                    int n2 = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Input k1: ");
                    int k1 = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Input k2: ");
                    int k2 = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Input matrix(n x m): ");
                    int[][] matrix2 = new int[n2][];
                    for (int i = 0; i < n2; i++)
                    {
                        matrix2[i] = Console.ReadLine()!.Trim().Split(' ').Select(int.Parse).ToArray();
                    }
                    try
                    {
                        int[] sums = Lab2.GetSumOfElementsInRange(matrix2, k1, k2);
                        Console.WriteLine("Sum of elements in each row: " + string.Join(", ", sums));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    break;
            }
        }
    }
}
