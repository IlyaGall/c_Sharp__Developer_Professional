using System.Collections;

namespace ProfHomeWork7
{
    /*
        Описание/Пошаговая инструкция выполнения домашнего задания:
        1. Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
        Функция должна принимать на вход делегат, преобразующий входной тип в число для возможности поиска максимального значения.
        public static T GetMax(this IEnumerable collection, Func<T, float> convertToNumber) where T : class;
        2. Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
        3. Оформить событие и его аргументы с использованием .NET соглашений:
        public event EventHandler FileFound;
        FileArgs – будет содержать имя файла и наследоваться от EventArgs
        4. Добавить возможность отмены дальнейшего поиска из обработчика;
        5. Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.

     */

    public static class Tsda
    {
        
        public static T GetMax<T>(this IEnumerable <T> collection, Func<T, float> convertToNumber) where T : class
        {
            float max = 0;
            T maxItemElement=null;
            foreach (var item in collection) 
            {
                float temp = convertToNumber(item);
                if (max < temp) 
                {
                    max = temp;
                    maxItemElement= item;
                }
            }

            return maxItemElement;
        }
    }

    internal class Program
    {

        class randomssss 
        {
            public int m = 0;
            public randomssss(int m) { this.m = m; }
        }

        static private float getNumber(randomssss r) 
        {
            return r.m; 
        }
        static void Main(string[] args)
        {


            List <randomssss> list = new List<randomssss>() {new randomssss(1), new randomssss(1), new randomssss(1), new randomssss(1)};
            list.GetMax<randomssss>(getNumber);
            Console.WriteLine("Hello, World!");
        }
    }
}
