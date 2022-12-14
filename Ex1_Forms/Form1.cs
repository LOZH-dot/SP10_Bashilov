using System;
using System.IO;
using System.Windows.Forms;

namespace Ex1_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            string root = @"C:\temp";

            if (Directory.Exists($@"{root}"))
            {
                MessageBox.Show($"Каталог {root} уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string result = string.Empty;

            result = ($"t1.txt info:\n");
            result += ($"Дата создания: {t1Info.CreationTime}\n");
            result += ($"Полное имя: {t1Info.FullName}\n");
            result += ($"Атрибуты: {t1Info.Attributes}\n");
            result += ($"Расширение: {t1Info.Extension}\n");
            result += ($"Директория: {t1Info.Directory}\n");

            result += ($"\nt2.txt info:\n");
            result += ($"Дата создания: {t2Info.CreationTime}\n");
            result += ($"Полное имя: {t2Info.FullName}\n");
            result += ($"Атрибуты: {t2Info.Attributes}\n");
            result += ($"Расширение: {t2Info.Extension}\n");
            result += ($"Директория: {t2Info.Directory}\n");

            result += ($"\nt3.txt info:\n");
            result += ($"Дата создания: {t3Info.CreationTime}\n");
            result += ($"Полное имя: {t3Info.FullName}\n");
            result += ($"Атрибуты: {t3Info.Attributes}\n");
            result += ($"Расширение: {t3Info.Extension}\n");
            result += ($"Директория: {t3Info.Directory}\n");

            File.Move($@"{root}\K1\t2.txt", $@"{root}\K2\t2.txt");
            File.Copy($@"{root}\K1\t1.txt", $@"{root}\K2\t1.txt");

            Directory.Move($@"{root}\K2", $@"{root}\All");
            DirectoryInfo allInfo = new DirectoryInfo($@"{root}\All");
            File.Delete($@"{root}\K1\t1.txt");
            Directory.Delete($@"{root}\K1");

            result += ($"\nAll info:\n");
            result += ($"Дата создания: {allInfo.CreationTime}\n");
            result += ($"Полное имя: {allInfo.FullName}\n");
            result += ($"Атрибуты: {allInfo.Attributes}\n");
            result += ($"Расширение: {allInfo.Extension}\n");
            result += ($"Корень: {allInfo.Root}\n");

            MessageBox.Show(result, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
