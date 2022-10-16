using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;



namespace HelloApp
{
    
class Person
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            string pathf = @"D:\Документы\Гаврилова БББО-07-21\os1\workfile";
            DirectoryInfo dirInfo = new DirectoryInfo(pathf);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Console.WriteLine("Введите имя: ");
            string na = Console.ReadLine();
            Console.WriteLine("Укажите возраст: ");
            string ag = Console.ReadLine();
            // сохранение данных
            using (FileStream fs = new FileStream(@"D:\Документы\Гаврилова БББО-07-21\os1\workfile\wfile_3.json", FileMode.OpenOrCreate))
            {
                Person poke = new Person()
                {
                    Name = na,
                    Age = ag
                };
                await JsonSerializer.SerializeAsync<Person>(fs, poke);
                Console.WriteLine("Данные сохранены в файл.");
            }

            // чтение данных
            using (FileStream fs = new FileStream(@"D:\Документы\Гаврилова БББО-07-21\os1\workfile\wfile_3.json", FileMode.OpenOrCreate))
            {
                Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
                Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
            }

            string pathmf = @"D:\Документы\Гаврилова БББО-07-21\os1\workfile\wfile_3.json";
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
    }
}