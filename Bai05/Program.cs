using System.Numerics;

public class Program
{
    public static void Main()
    {
        Console.Write("Nhap so luong bat dong san: ");
        int n = NhapSo();
        BDS[] arr = new BDS[n];
        Console.WriteLine("\nNhap danh sach bds");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nBDS thu {i + 1}");
            Console.Write("Nhap loai bds (1 - Khu Dat, 2 - Nha Pho, 3 - Chung Cu): ");
            int k = int.Parse(Console.ReadLine());
            switch(k)
            {
                case 1:
                    arr[i] = new KhuDat();
                    arr[i].Nhap();
                    break;
                case 2:
                    arr[i] = new NhaPho();
                    arr[i].Nhap();
                    break;
                case 3:
                    arr[i] = new ChungCu();
                    arr[i].Nhap();
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine("\nDanh sach bds\n");
        foreach(BDS bds in arr)
        {
            bds.Xuat();
            Console.WriteLine();
        }

        Console.Write("Tong gia ban bds (VND): " + TongGiaBan(arr));
        Console.WriteLine();

        XuatCoDK(arr);

        TimKiem(arr);
    }

    static double TongGiaBan(BDS[] arr)
    {
        double sum = 0;
        foreach (BDS bds in arr)
        {
            sum += bds.GetGiaBan();
        }
        return sum;
    }

    static void XuatCoDK(BDS[] arr)
    {
        Console.WriteLine("Danh sach bds theo dieu kien\n");
        bool found = false;
        foreach (BDS bds in arr)
        {
            if (bds.GetType() == typeof(KhuDat) && bds.GetDienTich() > 100.0)
            {
                bds.Xuat();
                Console.WriteLine();
                found = true;
            }
            if (bds is NhaPho nhaPho && bds.GetDienTich() > 60.0 && nhaPho.getNamXayDung() >= 2019)
            {
                nhaPho.Xuat();
                Console.WriteLine();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Khong co bds nao thoa dieu kien\n");
        }
    }

    static void TimKiem(BDS[] arr)
    {
        Console.WriteLine("Nhap thong tin can tim");
        Console.Write("Dia diem: "); string _diaDiem = Console.ReadLine() ?? "";
        Console.Write("Gia ban: "); double _giaBan = Convert.ToDouble(Console.ReadLine());
        Console.Write("Dien tich: "); double _dienTich = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nDanh sach cac bds tuong ung\n");
        bool found = false;
        foreach(BDS bds in arr)
        {
            if (bds.GetDiaDiem().ToLower() ==  _diaDiem.ToLower() &&
                bds.GetGiaBan() <= _giaBan && bds.GetDienTich() >= _dienTich)
            {
                bds.Xuat();
                Console.WriteLine();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Khong tim thay bds nao tuong ung");
        }
    }
    static int NhapSo()
    {
        string input = Console.ReadLine();
        if (!BigInteger.TryParse(input, out BigInteger n))
        {
            Console.WriteLine("Du lieu khong hop le. Nhap so nguyen duong");
            Environment.Exit(0);
        }
        if (n <= 0)
        {
            Console.WriteLine("So khong hop le. Nhap so nguyen duong");
            Environment.Exit(0);
        }
        if (n > int.MaxValue || n < int.MinValue)
        {
            Console.WriteLine("So qua lon/nho (Vuot qua gioi han).");
            Environment.Exit(0);
        }
        return (int)n;
    }

}