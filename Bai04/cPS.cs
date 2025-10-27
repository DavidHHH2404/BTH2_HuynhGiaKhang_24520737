using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
public class PhanSo
{
        private int tuSo;
        private int mauSo;

        public PhanSo()
        {
            tuSo = 0;
            mauSo = 1;
        }
        public PhanSo(int tuSo, int mauSo)
        {
            if (mauSo == 0)
            {
                Console.WriteLine("Mau so khong duoc bang 0.");
                Environment.Exit(0);
            }
            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
            int gcd = GCD(Math.Abs(tuSo), Math.Abs(mauSo));
            this.tuSo = tuSo/gcd;
            this.mauSo = mauSo/gcd;
        }

        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                return GCD(b, a % b);
            }
            return a;
        }

        public static int NhapSo()
        {
            string input = Console.ReadLine();
            if (!BigInteger.TryParse(input, out BigInteger n))
            {
                Console.WriteLine("Du lieu khong hop le. Nhap so nguyen.");
                Environment.Exit(0);
            }
            
            if (n > int.MaxValue || n < int.MinValue)
            {
                Console.WriteLine("So qua lon/nho (Vuot qua gioi han).");
                Environment.Exit(0);    
            }
            return (int)n;
        }
        public void Nhap()
        {
            Console.Write("Tu so: ");
            tuSo = NhapSo();
            Console.Write("Mau so: ");
            mauSo = NhapSo();
            if (mauSo == 0)
            {
                Console.WriteLine("Mau so khong duoc bang 0.");
                Environment.Exit(0);
            }
            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
            int gcd = GCD(Math.Abs(tuSo), Math.Abs(mauSo));
            tuSo /= gcd;
            mauSo /= gcd;
        }
        public void Xuat()
        {
            if (mauSo == 1)
            {
                Console.WriteLine(tuSo);
                return;
            }
            Console.Write($"{tuSo}/{mauSo}");
        }
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int tuMoi = a.tuSo * b.mauSo + b.tuSo * a.mauSo;
            int mauMoi = a.mauSo * b.mauSo;
            return new PhanSo(tuMoi, mauMoi); 
        }

        // Toán tử Trừ (-)
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            int tuMoi = a.tuSo * b.mauSo - b.tuSo * a.mauSo;
            int mauMoi = a.mauSo * b.mauSo;
            return new PhanSo(tuMoi, mauMoi);
        }

        // Toán tử Nhân (*)
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            int tuMoi = a.tuSo * b.tuSo;
            int mauMoi = a.mauSo * b.mauSo;
            return new PhanSo(tuMoi, mauMoi);
        }

        // Toán tử Chia (/)
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            int tuMoi = a.tuSo * b.mauSo;
            int mauMoi = a.mauSo * b.tuSo;
            return new PhanSo(tuMoi, mauMoi);
        }
        public float XuatTP()
        {
        return (float)tuSo / mauSo;
        }
} 


