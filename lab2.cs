using static System.Runtime.InteropServices.JavaScript.JSType;
using MathNet.Numerics.LinearAlgebra;

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
            M = M*M;
        }
        return M;
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
            }
        }
    }
}
