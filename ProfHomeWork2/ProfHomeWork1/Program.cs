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
        static void Main(string[] args)
        {
            NumberOfSpaces numberOfSpaces = new NumberOfSpaces();
            numberOfSpaces.GetSpace(@"C:\\Users\\Ilya\\Desktop\\Новая папка (54)\\Новый текстовый документ (2).txt");

            Task task = new Task(() => Console.WriteLine("Hello Task!"));
            task.Start();
            Console.WriteLine("Hello, World!");
        }
    }
}
