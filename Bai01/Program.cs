using System;

public class Bai01
{
    struct Date
    {
        public int month;
        public int year;
    }
    static bool checkDate(Date n)
    {
        if (n.year < 0 || n.month < 1 || n.month > 12 )
        {
            return false;
        }
        return true;
    }
    static bool checkNamNhuan(int year)
    {
        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            return true;
        return false;
    }

    static int LayNgayTrongThang(int month, int year)
    {
       switch(month)
       {
            case 1: case 3: case 5: case 7: case 8: case 10:
                return 31;
                break;
            case 4: case 6: case 9: case 11:
                return 30;
                break;
            case 2:
                if (checkNamNhuan(year))
                    return 29;
                else
                    return 28;
                break;
            default:
                return 0;
        }
    }

    static public void Main()
    {
        Date n = new Date();
        bool a, b;
        Console.Write("Nhap thang: ");
        a = int.TryParse(Console.ReadLine(), out n.month);
        Console.Write("Nhap nam: ");
        b = int.TryParse(Console.ReadLine(), out n.year);
        if (a && b && checkDate(n))
        {
            string s = n.month.ToString("D2");
            Console.WriteLine($"Month: {s}/{n.year}");
            Console.WriteLine("Sun   Mon   Tue   Wed   Thu   Fri   Sat");
            string S = $"01/{s}/{n.year}";
            if (DateTime.TryParseExact(S, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                int SoNgayCuaThang = LayNgayTrongThang(n.month, n.year);
                int ThuDauTien = (int)date.DayOfWeek;
                for (int i = 0; i < ThuDauTien; i++)
                {
                    Console.Write("      ");
                }
                for (int i = 1; i <= SoNgayCuaThang; i++)
                {
                    Console.Write($"{i, 2}    ");
                    if ((i + ThuDauTien) % 7 == 0)
                    {
                        Console.WriteLine();
                    }
                }
            } 
        }
        else
        {
            Console.WriteLine("Dau vao khong hop le");
        }
    }
}