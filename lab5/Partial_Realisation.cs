using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    sealed partial class VectorByte
    {
        partial void Input()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"[{i}] = ");
                BArray[i] = byte.Parse(Console.ReadLine());
            }
        }
        partial void Print()
        {
            for (int i = 0; i < n; i++) Console.Write(BArray[i] + " ");
            Console.WriteLine();
        }

        partial void setValue(byte value)
        {
            for (int i = 0; i < n; i++) BArray[i] = value;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            VectorByte v1 = new VectorByte(5, 10);
            VectorByte v2 = new VectorByte(5, 20);
            Console.WriteLine("v1: ");
            v1.Print();
            Console.WriteLine("v2: ");
            v2.Print();
            Console.WriteLine("v1 + v2: ");
            (v1 + v2).Print();
            Console.WriteLine("v1 * 2: ");
            (v1 * 2).Print();
            Console.WriteLine($"Number of vectors: {VectorByte.GetNumVec()}");
        }
    }
}
