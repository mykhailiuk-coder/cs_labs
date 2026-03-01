using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
// Tools → NuGet Package Manager → Package Manager Console
// Install-Package MathNet.Numerics
using MathNet.Numerics.LinearAlgebra;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input task: ");
            int task = int.Parse(Console.ReadLine());
            while (task > 0)
            {
                switch (task) 
                {
                    case 1:
                        Console.WriteLine("Input array: ");
                        int[] numbers1 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                        Console.Write("Input a: ");
                        int a = int.Parse(Console.ReadLine());
                        Console.Write("Input b: ");
                        int b = int.Parse(Console.ReadLine());
                        List<int> filteredNumbers = new List<int>() { };
                        foreach (int num in numbers1)
                        {
                            if (num < a || num > b)
                            {
                                filteredNumbers.Add(num);
                            }
                        }
                        Console.Write("Filtered array size: " + filteredNumbers.Count);
                        break;
                    case 2:
                        Console.WriteLine("Input array: ");
                        int[] numbers2 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                        int min = numbers2[0];
                        foreach (int num in numbers2) 
                        {
                            if (num < min) 
                            { 
                                min = num;
                            }
                        }
                        Console.Write("Array minimum:" + min);
                        break;
                    case 3:
                        Console.Write("Input n: ");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Input matrix(n x n): ");
                        var matrix = Matrix<double>.Build.Dense(n, n);
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write($"matrix[{i},{j}]: ");
                                matrix[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                        var result = matrix;
                        for (int i = 1; i < n; i++)
                        {
                            result = result * matrix;
                        }
                        Console.WriteLine("Result: ");
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write(result[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                        break;
                }
            }
        }
    }
}
