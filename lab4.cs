using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class VectorByte
    {
        protected byte[] BArray;
        protected uint n { get; }
        protected int codeError { get; set; }
        protected static uint num_vec = 0;

        public VectorByte()
        {
            this.BArray = new byte[1];
            this.BArray[0] = 0;
            num_vec++;
        }
        public VectorByte(uint n)
        {
            this.n = n;
            this.BArray = new byte[n];
            for (int i = 0; i < n; i++)
                this.BArray[i] = 0;
            num_vec++;
        }
        public VectorByte(uint n, byte value)
        {
            this.n = n;
            this.BArray = new byte[n];
            for (int i = 0; i < n; i++)
                this.BArray[i] = value;
            num_vec++;
        }
        ~VectorByte()
        {
            Console.WriteLine("Destructor called for VectorByte");
        }
        public void inputValues()
        {
            Console.WriteLine("Enter the number of elements:");
            this.BArray = new byte[this.n];
            Console.WriteLine("Enter the elements:");
            for (int i = 0; i < this.n; i++)
                this.BArray[i] = byte.Parse(Console.ReadLine());
        }
        public void outputValues()
        {
            for (int i = 0; i < this.n; i++)
                Console.Write(this.BArray[i] + " ");
        }
        public void setValue(byte value)
        {
            for (int i = 0; i < this.n; i++)
                this.BArray[i] = value;
        }
        public static void showNumVec()
        {
            Console.WriteLine("Number of VectorByte instances: " + num_vec);
        }
        public int this[int index]
        {
            get 
            {
                return 0;
            }
            set
            {
                if (index < 0 || index > this.n) 
                {
                    this.codeError = 1;
                }
            }
        }
        public static VectorByte operator++(VectorByte vec)
        {
            for (int i = 0; i < vec.n; i++)
                vec.BArray[i]++;
            return vec;
        }
        public static bool operator true(VectorByte vec)
        {
            bool result = true;
            if (vec.n != 0)
                return true;
            for (int i = 0; i < vec.n; i++) 
            { 
                if (vec.BArray[i] == 0)
                    result = false;
            }
            return result;
        }
}
    public class Program
    {
        static void Main(string[] args)
        {
            VectorByte vec1 = new VectorByte();
            VectorByte vec2 = new VectorByte();
            VectorByte.showNumVec();
        }
    }
}
