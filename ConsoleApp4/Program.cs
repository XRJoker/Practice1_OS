using System.IO.Compression;
using System.Text;
using System.IO;
string path = @"D:\УЧЁБА\Домашнее Задания\тбд\jtest.xml";
try
{
    Console.WriteLine("Введите данные в  файл > ");
    using (FileStream fs = File.Create(path))
    {
        byte[] info = new UTF8Encoding(true).GetBytes(Console.ReadLine());
        fs.Write(info, 0, info.Length);
    }

    using (StreamReader sr = File.OpenText(path))
    {
        string s = "";
        while ((s = sr.ReadLine()) != null)
        {
            Console.WriteLine(s);
        }
    }

    string pathmf = @"D:\УЧЁБА\Домашнее Задания\тбд\jtest.xml";
    FileInfo fileInf = new FileInfo(pathmf);
    if (fileInf.Exists)
    {
        Console.WriteLine($"Вы хотите удалить файл? 0 - нет 1 - да");
        string ansdel = Console.ReadLine();
        if (ansdel == "0")
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
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}