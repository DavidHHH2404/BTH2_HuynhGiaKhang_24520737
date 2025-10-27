
using System.Numerics;

public class Program
{
    public static void Main()
    {
        int k;
        Console.Write("Nhap phan chuong trinh muon thuc thi (1/2): ");
        k = int.Parse(Console.ReadLine());
        switch(k)
        {
            case 1:
                P1();
                break;
            case 2:
                P2();
                break;
            default:
                break;
        }
     
    }
    static void P1()
    {
        PhanSo ps1 = new PhanSo();
        Console.WriteLine("Nhap phan so 1:");
        ps1.Nhap();
        Console.WriteLine("\nNhap phan so 2:");
        PhanSo ps2 = new PhanSo();
        ps2.Nhap();
        Console.Write("\nTong 2 phan so: "); (ps1 + ps2).Xuat();
        Console.Write("Hieu 2 phan so: "); (ps1 - ps2).Xuat();
        Console.Write("Tich 2 phan so: "); (ps1 * ps2).Xuat();
        Console.Write("Thuong 2 phan so: "); (ps1 / ps2).Xuat();
    }

    static void P2()
    {
        Console.Write("Nhap so phan tu: ");
        int n = NhapSo();
        PhanSo[] arr = new PhanSo[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhap phan so thu {i + 1}:");
            arr[i] = new PhanSo();
            arr[i].Nhap();
        }
        PhanSo max = MaxPS(arr, n);
        Console.WriteLine("\nPhan so lon nhat: ");
        max.Xuat();
        Console.WriteLine("\nMang sau khi sap xep tang dan: ");
        SortPS(arr, n);
        for (int i = 0; i < n; i++)
        {
            arr[i].Xuat();
            Console.Write(" ");
        }
        Console.WriteLine();
    }

    static PhanSo MaxPS(PhanSo[] arr, int n)
    {
        PhanSo max = arr[0];
        for (int i = 1; i < n; i++)
        {
            if (arr[i].XuatTP() > max.XuatTP())
            {
                max = arr[i];
            }
        }
        return max;
    }
    static void SortPS(PhanSo[] arr, int n)
    {
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (arr[i].XuatTP() > arr[j].XuatTP())
                {
                    PhanSo temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }
    static int NhapSo()
    {
        string input = Console.ReadLine();
        if (!BigInteger.TryParse(input, out BigInteger n))
        {
            Console.WriteLine("Du lieu khong hop le. Nhap so nguyen duong.");
            Environment.Exit(0);
        }

        if (n < 0)
        {             
            Console.WriteLine("So phan tu khong the am. Nhap so nguyen duong.");
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