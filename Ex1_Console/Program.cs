using System;
using System.IO;

namespace Ex1_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string root = @"C:\temp1";

            if (Directory.Exists($@"{root}"))
            {
                Console.WriteLine($"Каталог {root} уже существует!");
                return;
            }


            Directory.CreateDirectory(root);
            Directory.CreateDirectory($@"{root}\K1");
            Directory.CreateDirectory($@"{root}\K2");

            File.Create($@"{root}\K1\t1.txt").Close();
            File.Create($@"{root}\K1\t2.txt").Close();

            using (StreamWriter sw = new StreamWriter($@"{root}\K1\t1.txt"))
                sw.WriteLine("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");

            using (StreamWriter sw = new StreamWriter($@"{root}\K1\t2.txt"))
                sw.WriteLine("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");

            File.Create($@"{root}\K2\t3.txt").Close();

            string sum = string.Empty;

            using (StreamReader sr = new StreamReader($@"{root}\K1\t1.txt"))
                sum = sr.ReadToEnd();

            using (StreamReader sr = new StreamReader($@"{root}\K1\t2.txt"))
                sum += sr.ReadToEnd();

            using (StreamWriter sw = new StreamWriter($@"{root}\K2\t3.txt"))
                sw.WriteLine(sum);

            FileInfo t1Info = new FileInfo($@"{root}\K1\t1.txt");
            FileInfo t2Info = new FileInfo($@"{root}\K1\t2.txt");
            FileInfo t3Info = new FileInfo($@"{root}\K2\t3.txt");

            Console.WriteLine($"t1.txt info:");
            Console.WriteLine($"Дата создания: {t1Info.CreationTime}");
            Console.WriteLine($"Полное имя: {t1Info.FullName}");
            Console.WriteLine($"Атрибуты: {t1Info.Attributes}");
            Console.WriteLine($"Расширение: {t1Info.Extension}");
            Console.WriteLine($"Директория: {t1Info.Directory}");

            Console.WriteLine($"\nt2.txt info:");
            Console.WriteLine($"Дата создания: {t2Info.CreationTime}");
            Console.WriteLine($"Полное имя: {t2Info.FullName}");
            Console.WriteLine($"Атрибуты: {t2Info.Attributes}");
            Console.WriteLine($"Расширение: {t2Info.Extension}");
            Console.WriteLine($"Директория: {t2Info.Directory}");

            Console.WriteLine($"\nt3.txt info:");
            Console.WriteLine($"Дата создания: {t3Info.CreationTime}");
            Console.WriteLine($"Полное имя: {t3Info.FullName}");
            Console.WriteLine($"Атрибуты: {t3Info.Attributes}");
            Console.WriteLine($"Расширение: {t3Info.Extension}");
            Console.WriteLine($"Директория: {t3Info.Directory}");

            File.Move($@"{root}\K1\t2.txt", $@"{root}\K2\t2.txt");
            File.Copy($@"{root}\K1\t1.txt", $@"{root}\K2\t1.txt");

            Directory.Move($@"{root}\K2", $@"{root}\All");
            DirectoryInfo allInfo = new DirectoryInfo($@"{root}\All");
            File.Delete($@"{root}\K1\t1.txt");
            Directory.Delete($@"{root}\K1");

            Console.WriteLine($"\nAll info:");
            Console.WriteLine($"Дата создания: {allInfo.CreationTime}");
            Console.WriteLine($"Полное имя: {allInfo.FullName}");
            Console.WriteLine($"Атрибуты: {allInfo.Attributes}");
            Console.WriteLine($"Расширение: {allInfo.Extension}");
            Console.WriteLine($"Корень: {allInfo.Root}");
        }
    }
}
