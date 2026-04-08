using lab4;
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

        public void Input()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"[{i}] = ");
                BArray[i] = byte.Parse(Console.ReadLine());
            }
        }

        public void Print()
        {
            for (int i = 0; i < n; i++) Console.Write(BArray[i] + " ");
            Console.WriteLine();
        }

        public void setValue(byte value)
        {
            for (int i = 0; i < this.n; i++)
            {
                BArray[i] = value;
            }
        }

        static public uint GetNumVec() => num_vec;

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

        public static VectorByte operator ++(VectorByte v)
        {
            for (int i = 0; i < v.n; i++) v.BArray[i]++;
            return v;
        }

        public static VectorByte operator --(VectorByte v)
        {
            for (int i = 0; i < v.n; i++) v.BArray[i]--;
            return v;
        }

        public static bool operator true(VectorByte v) => v.n != 0;
        public static bool operator false(VectorByte v) => v.n == 0;
        public static bool operator !(VectorByte v) => v.n != 0;

        public static VectorByte operator +(VectorByte v1, VectorByte v2)
        {
            uint max = Math.Max(v1.n, v2.n);
            VectorByte res = new VectorByte(max);
            for (int i = 0; i < Math.Min(v1.n, v2.n); i++) res[i] = (byte)(v1[i] + v2[i]);
            return res;
        }

        public static VectorByte operator +(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] + s);
            return res;
        }

        public static VectorByte operator -(VectorByte v1, VectorByte v2)
        {
            uint max = Math.Max(v1.n, v2.n);
            VectorByte res = new VectorByte(max);
            for (int i = 0; i < Math.Min(v1.n, v2.n); i++) res[i] = (byte)(v1[i] - v2[i]);
            return res;
        }

        public static VectorByte operator -(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] - s);
            return res;
        }

        public static VectorByte operator *(VectorByte v1, VectorByte v2)
        {
            uint max = Math.Max(v1.n, v2.n);
            VectorByte res = new VectorByte(max);
            for (int i = 0; i < Math.Min(v1.n, v2.n); i++) res[i] = (byte)(v1[i] * v2[i]);
            return res;
        }

        public static VectorByte operator *(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] * s);
            return res;
        }

        public static VectorByte operator /(VectorByte v1, VectorByte v2)
        {
            uint max = Math.Max(v1.n, v2.n);
            VectorByte res = new VectorByte(max);
            for (int i = 0; i < Math.Min(v1.n, v2.n); i++) res[i] = v2[i] != 0 ? (byte)(v1[i] / v2[i]) : (byte)0;
            return res;
        }

        public static VectorByte operator /(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = s != 0 ? (byte)(v[i] / s) : (byte)0;
            return res;
        }

        public static bool operator ==(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if (v1[i] != v2[i]) return false;
            return true;
        }

        public static bool operator !=(VectorByte v1, VectorByte v2) => !(v1 == v2);

        public static bool operator >(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if (v1[i] <= v2[i]) return false;
            return true;
        }

        public static bool operator <(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if (v1[i] >= v2[i]) return false;
            return true;
        }

        public static bool operator >=(VectorByte v1, VectorByte v2) => (v1 > v2) || (v1 == v2);

        public static bool operator <=(VectorByte v1, VectorByte v2) => (v1 < v2) || (v1 == v2);

        public static bool operator |(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if (v1[i] != 0 && v2[i] != 0) return true;
            return false;
        }

        public static bool operator |(VectorByte v, byte s)
        {
            if (s == 0) return false;
            for (int i = 0; i < v.n; i++) if (v[i] != 0) return true;
            return false;
        }

        public static bool operator ^(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return false;
            for (int i = 0; i < v1.n; i++) if ((v1[i] != 0) ^ (v2[i] != 0)) return true;
            return false;
        }

        public static bool operator ^(VectorByte v, byte s)
        {
            if (s == 0) return false;
            for (int i = 0; i < v.n; i++) if ((v[i] != 0) ^ (s != 0)) return true;
            return false;
        }

        public static VectorByte operator >>(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return new VectorByte(0);
            VectorByte res = new VectorByte(v1.n);
            for (int i = 0; i < v1.n; i++) res[i] = (byte)(v1[i] > v2[i] ? 1 : 0);
            return res;
        }

        public static VectorByte operator >>(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] > s ? 1 : 0);
            return res;
        }

        public static VectorByte operator <<(VectorByte v1, VectorByte v2)
        {
            if (v1.n != v2.n) return new VectorByte(0);
            VectorByte res = new VectorByte(v1.n);
            for (int i = 0; i < v1.n; i++) res[i] = (byte)(v1[i] < v2[i] ? 1 : 0);
            return res;
        }

        public static VectorByte operator <<(VectorByte v, byte s)
        {
            VectorByte res = new VectorByte(v.n);
            for (int i = 0; i < v.n; i++) res[i] = (byte)(v[i] < s ? 1 : 0);
            return res;
        }

        struct InfoStruct
        {
            public string Medium;
            public double Volume;
            public string Name;
            public string Author;
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

            List<InfoStruct> listStruct = new List<InfoStruct>();

            List<(string Medium, double Volume, string Name, string Author)> listTuples = new List<(string Medium, double Volume, string Name, string Author)> { };
            listTuples.Add(("USB", 16.0, "Data1", "Author A"));
            listTuples.Add(("HDD", 500.0, "Data2", "Author B"));

            double targetVol = 16.0;
            var toRemove = listTuples.FirstOrDefault(x => x.Volume == targetVol);
            listTuples.Remove(toRemove);
            int targetIndex = 1;
            listTuples.Insert(targetIndex - 1, ("SSD", 256.0, "NewData", "Author C"));

            for (int i = 0; i < listTuples.Count; i++)
            {
                Console.WriteLine($"Medium: {listTuples[i].Medium}, Volume: {listTuples[i].Volume}, Name: {listTuples[i].Name}, Author: {listTuples[i].Author}");
            }
        }
    }
}
