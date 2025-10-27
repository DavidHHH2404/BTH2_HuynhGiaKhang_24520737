using System;
using System.Numerics;
public class Program
{
    static int NhapSo()
    {
        string input = Console.ReadLine();
        if (!BigInteger.TryParse(input, out BigInteger n))
        {
            Console.WriteLine("Du lieu khong hop le. Nhap so nguyen");
            return -1;
        }
        if (n < 0)
        {
            Console.WriteLine("So dong hoac cot lon hon 0.");
            return -1;
        }
        if (n == 0)
        {
            Console.WriteLine("So dong hoac cot khong the bang 0.");
            return -1;
        }
        if (n > int.MaxValue || n < int.MinValue)
        {
            Console.WriteLine("So qua lon/nho (Vuot qua gioi han).");
            return -1;
        }
        return (int)n;
    }
    static void Main(string[] args)
    {
        Matrix a = new Matrix();
        a.NhapMaTran();
        a.XuatMaTran();

        Console.Write("Nhap phan tu can tim : ");
        int f = Utils.NhapPhanTu();
        a.TimPhanTu(f);

        a.XuatCacSNT();

        a.DongCoNhieuSNTNhat();
        Console.WriteLine();
    }

    public class Matrix
    {
        int[,] mat;
        int n, m;

        public Matrix(int n = 1, int m = 1)
        {
            this.n = n;
            this.m = m;
        }

        // nhap ma tran
        public void NhapMaTran()
        {
            Console.Write("Nhap so dong : ");
            n = NhapSo();
            if (n == -1) Environment.Exit(1);

            Console.Write("Nhap so cot : ");
            m = NhapSo();
            if (m == -1) Environment.Exit(1);

            mat = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    mat[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // xuat ma tran
        public void XuatMaTran()
        {
            Console.WriteLine("Ma tran vua nhap : ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(mat[i, j] + " ");
                Console.WriteLine();
            }
        }

        public void TimPhanTu(int k)
        {
            List<(int, int)> vitri = new List<(int, int)>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    if (mat[i, j] == k)
                    {
                        vitri.Add((i, j));
                    }
            }
            if (vitri.Count > 0)
            {
                Console.WriteLine($"Tim thay phan tu {k} tai cac vi tri : ");
                foreach (var item in vitri)
                {
                    Console.WriteLine($"Dong {item.Item1}, Cot {item.Item2}");
                }
                return;
            }
            Console.WriteLine($"Khong tim thay phan tu {k}");
        }

        public void XuatCacSNT()
        {
            HashSet<int> snt_set = new HashSet<int>();
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Utils.LaSNT(mat[i, j]) && !snt_set.Contains(mat[i, j]))
                    {
                        snt_set.Add(mat[i, j]);
                    }
                }
            }
            if (snt_set.Count == 0)
            {
                Console.Write("Khong co so nguyen to nao trong ma tran.");
                Environment.Exit(0);
            } else
            {
                Console.Write("Cac so nguyen to: ");
                foreach (var item in snt_set)
                {
                    Console.Write(item + " ");
                }
            }
            Console.WriteLine();
        }

        public void DongCoNhieuSNTNhat()
        {
            HashSet<int> snt_set = new HashSet<int>();
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                int cnt = 0;
                for (int j = 0; j < m; j++)
                    if (Utils.LaSNT(mat[i, j]))
                        cnt++;
                if (cnt > r)
                {
                    r = cnt;
                    snt_set.Clear();
                    snt_set.Add(i);
                }
                else if (cnt == r && r != 0)
                {
                    snt_set.Add(i);
                }
            }
            Console.Write($"Dong ");
            foreach (var item in snt_set)
            {
                Console.Write(item + " ");
            }    
            Console.WriteLine("co nhieu so nguyen to nhat.");
        }
    }
}

public class Utils
{   public static int NhapPhanTu()
    {
        string input = Console.ReadLine();
        if (!BigInteger.TryParse(input, out BigInteger n))
        {
            Console.WriteLine("Du lieu khong hop le. Nhap so nguyen");
            Environment.Exit(1);
        }
        if (n > int.MaxValue || n < int.MinValue)
        {
            Console.WriteLine("So qua lon/nho (Vuot qua gioi han).");
            Environment.Exit(1);
        }
        return (int)n;
    }
    public static bool LaSNT(int n)
    {
        if (n <= 1) return false;
        if (n <= 3) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;
        for (int i = 5; i <= Math.Sqrt(n); i += 6)
        {
            if (n % i == 0 || (n % (i + 2)) == 0) return false;
        }
        return true;
    }
}