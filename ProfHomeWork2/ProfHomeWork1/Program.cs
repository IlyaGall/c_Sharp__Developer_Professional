using System.Diagnostics;

namespace ProfHomeWork1
{

    /*
     Описание/Пошаговая инструкция выполнения домашнего задания:
     Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
     Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
     Замерьте время выполнения кода (класс Stopwatch).
     */
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<string> listPathFiles = new List<string>()
            {
                 @"C:\\Users\\Ilya\\Desktop\\Новая папка (54)\\Новый текстовый документ (2).txt",
                 @"C:\\Users\\Ilya\\Desktop\\Новая папка (54)\\Новый текстовый документ.txt",
                 @"C:\\Users\\Ilya\\Desktop\\Новая папка (54)\\Новый текстовый документ (3).txt"
            };

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var cts = new CancellationTokenSource();
            List<Task<int>> tasks = new List<Task<int>>();

            for (int i = 0; i <= 2; i++)
            {
                int iTask = i; // проблемма с итератором он присваивает 3
                tasks.Add(Task.Run(() => 
                     NumberOfSpaces.GetSpace(listPathFiles[iTask])));
            }
            int[] results = await Task.WhenAll(tasks);

    
            stopwatch.Stop();
            Console.WriteLine($"Task timer {stopwatch} rezult: {results[0]} {results[1]} {results[2]} \n{results.Sum()}");

            stopwatch.Start();
            NumberOfSpaces.GetSpace(listPathFiles[0]);
            NumberOfSpaces.GetSpace(listPathFiles[1]);
            NumberOfSpaces.GetSpace(listPathFiles[2]);
            stopwatch.Stop();
            Console.WriteLine($"No Task timer {stopwatch}");
            




            NumberOfSpaces.GetSpace(@"C:\\Users\\Ilya\\Desktop\\Новая папка (54)\\Новый текстовый документ (2).txt");
       
            Task task = new Task(() => Console.WriteLine("Hello Task!"));
            task.Start();
            Console.WriteLine("Hello, World!");
        }
    }
}
