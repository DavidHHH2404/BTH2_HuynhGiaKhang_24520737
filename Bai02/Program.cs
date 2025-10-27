using System;
using System.IO; 
using System.Globalization; 

class Program
{
    static void Main()
    {
        Console.Write("Nhap duong dan thu muc (vi du: D:\\): ");
        string path = Console.ReadLine() ?? "";

        if (Directory.Exists(path))
        {
            Console.WriteLine("\n");
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                Console.WriteLine($"{dir.LastWriteTime.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)}    <DIR>          {dir.Name}");
            }

            foreach (FileInfo file in dirInfo.GetFiles())
            {
                Console.WriteLine($"{file.LastWriteTime.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture)}    {file.Length,15} {file.Name}");
            }
        }
        else
        {
            Console.WriteLine("Thu muc khong ton tai hoac duong dan khong hop le.");
        }

        Console.ReadKey();
    }
}