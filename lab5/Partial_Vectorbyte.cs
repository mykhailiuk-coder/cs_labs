using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// open .csproj file and change <LangVersion> to latest in the first <PropertyGroup>, or add it if it doesn't exist
// <LangVersion>latest</LangVersion>
namespace lab5
{
    public sealed partial class VectorByte
    {
        protected byte[] BArray;
        protected uint n { get; }
        protected int codeError { get; set; }
        protected static uint num_vec;

        public VectorByte()
        {
            BArray = new byte[1] { 0 };
            n = 1;
            codeError = 0;
            num_vec++;
        }

        public VectorByte(uint size)
        {
            BArray = new byte[size];
            n = size;
            codeError = 0;
            num_vec++;
        }

        public VectorByte(uint size, byte value)
        {
            BArray = new byte[size];
            for (int i = 0; i < size; i++) BArray[i] = value;
            n = size;
            codeError = 0;
            num_vec++;
        }

        ~VectorByte()
        {
            Console.WriteLine("VectorByte object destroyed");
        }

        partial void Input();

        public partial void Print();

        partial void setValue(byte value);

        static public int GetNumVec() => (int)num_vec;

        public uint Size => n;
        public int ErrorCode { get => codeError; set => codeError = value; }
        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= n) { codeError = 1; return 0; }
                return BArray[index];
            }
            set
            {
                if (index < 0 || index >= n) codeError = 1;
                else BArray[index] = value;
            }
        }

        public static VectorByte operator +(VectorByte v1, VectorByte v2)
        {
            uint max = Math.Max(v1.n, v2.n);
            VectorByte res = new VectorByte(max);
            for (int i = 0; i < Math.Min(v1.n, v2.n); i++) res[i] = (byte)(v1[i] + v2[i]);
            return res;
        }

        public static VectorByte operator *(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] * s);
            return res;
        }
    }
}
