using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

public abstract class BDS
{
    protected string diaDiem { get; set; }
    protected double giaBan { get; set; }
    protected double dienTich { get; set; }

    public virtual void Nhap()
    {
        Console.Write("Dia diem: ");
        diaDiem = Console.ReadLine() ?? "";
        Console.Write("Gia ban: ");
        giaBan = NhapSoDouble();
        Console.Write("Dien tich: ");
        dienTich = NhapSoDouble();
    }
    public virtual void Xuat()
    {
        Console.WriteLine($"Dia diem: {diaDiem}");
        Console.WriteLine($"Gia ban: {giaBan}");
        Console.WriteLine($"Dien tich: {dienTich}");
    }

    public double NhapSoDouble()
    {
        if(double.TryParse(Console.ReadLine(), out double so))
        {
            return so;
        }
        else
        {
            Console.Write("Nhap sai! Vui long nhap lai: ");
            return NhapSoDouble();
        }
    }

    public static int NhapSo()
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
    public double GetGiaBan() => giaBan;
    public double GetDienTich() => dienTich;
    public string GetDiaDiem() => diaDiem;
}

public class KhuDat : BDS
{
    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin khu dat:");
        base.Nhap();
    }
    public override void Xuat()
    {
        Console.WriteLine("Thong tin khu dat:");
        base.Xuat();
    }

}

public class NhaPho : BDS
{
    private int namXayDung;
    private int soTang;

    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin nha pho:");
        base.Nhap();
        Console.Write("Nam xay dung: ");
        namXayDung = NhapSo();
        Console.Write("So tang: ");
        soTang = NhapSo();
    }

    public override void Xuat()
    {
        Console.WriteLine("Thong tin nha pho:");
        base.Xuat();
        Console.WriteLine($"Nam xay dung: {namXayDung}");
        Console.WriteLine($"So tang: {soTang}");
    }

    public int getNamXayDung() => namXayDung;
    public int getSoTang() => soTang;
}

public class ChungCu : BDS
{
    private int soTang;

    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin chung cu:");
        base.Nhap();
        Console.WriteLine("Sso tang:");
        soTang = NhapSo();
    }

    public override void Xuat()
    {
        Console.WriteLine("Thong tin chung cu:");
        base.Xuat();
        Console.WriteLine($"So tang: {soTang}");
    }

    public int getSoTang() => soTang;
}