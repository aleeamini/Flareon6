using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace bmphidere
{
    class Program
    {
        public static byte b(byte b, int r)
        {
            int t = 0;
            for (int i = 0; i < r; i++)
            {
                int b2 = (b & 128) / 128;
                t = (b * 2 & byte.MaxValue) + b2;
                b = Convert.ToByte(t);
            }
            return b;
        }
        public static byte bb(byte b, int r)
        {
            byte t = 0;
            for (int i = 0; i < r; i++)
            {
                t=(byte)(b >> 7);
                b = (byte)((b << 1) |t);
                
            }
            return b;
        }
        public static byte rbb(byte b, int r)
        {
            byte t = 0;
            for (int i = 0; i < r; i++)
            {
                t =(byte) (b >>1);
                b =(byte) ((b << 7) | t);
            }
            return b;
        }
        public static byte d(byte b, int r)
        {
            int t=0;
            for (int i = 0; i < r; i++)
            {
                int b2 = (b & 1) * 128;
                t= (b / 2 & byte.MaxValue) + b2;
                b= Convert.ToByte(t);
            }
            return b;
        }
        public static byte dd(byte b, int r)
        {
            byte t = 0;
            for (int i = 0; i < r; i++)
            {
                t = (byte)(b << 7);
                b = (byte)((b >> 1) | t);

            }
            return b;
        }
        public static byte rdd(byte b, int r)
        {
            byte t = 0;
            for (int i = 0; i < r; i++)
            {
                t = (byte)(b << 1);
                b = (byte)((b >> 7) | t);

            }
            return b;
        }
        


        // Token: 0x06000012 RID: 18 RVA: 0x000027FC File Offset: 0x000027FC
        public static byte e(byte b, byte k)
        {
            for (int i = 0; i < 8; i++)
            {
                bool flag = (b >> i & 1) == (k >> i & 1);
                if (flag)
                {
                    b = (byte)((int)b & ~(1 << i) & 255);
                }
                else
                {
                    b = (byte)((int)b | (1 << i & 255));
                }
            }
            return b;
        }
        public static byte g(int idx)
        {
            byte b = (byte)((long)(idx + 1) * (long)((ulong)309030853));
            byte k = (byte)((idx + 2) * 209766781);
            return e(b, k);
        }
        public static byte[] h(byte[] data)
        {
            byte[] array = new byte[data.Length];
            int num = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int num2 = (int)g(num++);
                int num3 = (int)data[i];
                num3 = (int)e((byte)num3, (byte)num2);
                num3 = (int)b((byte)num3, 7);
                int num4 = (int)g(num++);
                num3 = (int)e((byte)num3, (byte)num4);
                num3 = (int)d((byte)num3, 3);
                array[i] = (byte)num3;
            }
            return array;
        }

        public static byte[] rh(byte[] data)
        {
            byte[] array = new byte[data.Length];
            int num = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int num2 = (int)g(num++);
                int num4 = (int)g(num++);
                int num3 = (int)data[i];

                num3 = (int)rdd((byte)num3, 3);
                num3 = (int)e((byte)num3, (byte)num4);

                num3 = (int)rbb((byte)num3, 7);
                num3 = (int)e((byte)num3, (byte)num2);
                
                array[i] = (byte)num3;
            }
            return array;
        }
        static void Main(string[] args)
        {
            /*var arr=new byte[]{0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27};
            var arr2 = new byte[8];
            var arr3 = new byte[8];
            for (int i=0;i<arr.Length;i++)
            {
                Console.Write(arr[i] + " ");
            }
            arr2 = h(arr);
            Console.WriteLine();
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            Console.WriteLine();
            arr3 = rh(arr2);

            for (int i = 0; i < arr3.Length; i++)
            {
                Console.Write(arr3[i] + " ");
            }
            Console.ReadLine();*/
            /*Console.WriteLine("encrypt 200 with b: "+b(200, 7));
            Console.WriteLine("encrypt 200 with bb: "+bb(200, 7));
            Console.WriteLine("Decrypt 100 with rbb: " + rbb(100, 7));

            Console.WriteLine("encrypt 200 with d: " + d(200, 3));
            Console.WriteLine("encrypt 200 with dd: " + dd(200, 3));
            Console.WriteLine("Decrypt  25 with rdd: " + rdd(25, 3));

            Console.WriteLine("encrypt 200,100 with e: " + e(200, 100));
            Console.WriteLine("Decrypt  172 with rbb: " + e(172, 100));*/

            byte[] encdata=File.ReadAllBytes("extdata");
            byte[] decdata = rh(encdata);

            Console.WriteLine("finished");
            File.WriteAllBytes("output", decdata);


            Console.ReadLine();


        }
    }
}
