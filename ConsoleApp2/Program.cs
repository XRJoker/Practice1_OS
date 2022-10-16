using System;
using System.IO;

namespace HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем каталог для файла
            string path = @"D:\Документы\Гаврилова БББО-07-21\os1\workfile";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();

            // запись в файл
            using (FileStream fstream = new FileStream($"{path}\\work2.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }

            // чтение из файла
            using (FileStream fstream = File.OpenRead($"{path}\\work2.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }

            Console.ReadLine();

            string pathf = $"{path}\\work2.txt";
            FileInfo fileInf = new FileInfo(pathf);
            if (fileInf.Exists)
            {
                Console.WriteLine($"Вы хотите удалить файл? 0 - нет 1 - да");
                string ansdel = Console.ReadLine();
                if (ansdel=="0")
                {
                    Console.WriteLine($"Ок.");
                }

                if (ansdel == "1")
                {
                    fileInf.Delete();
                    Console.WriteLine($"Файл удален.");
                }

                if (!(ansdel == "1") && !(ansdel == "0"))
                {
                    fileInf.Delete();
                    Console.WriteLine($"Error.");
                }
            }
        }
    }
}