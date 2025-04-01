using System;
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
            * public event EventHandler FileFound;
            * FileArgs – будет содержать имя файла и наследоваться от EventArgs
        4. Добавить возможность отмены дальнейшего поиска из обработчика;
        5. Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.

     */
    internal class Program
    {
        #region 1 task
        /// <summary>
        /// Класс для тестирования метода getMax
        /// </summary>
        class randomssss 
        {
            public int m = 0;
            public randomssss(int m) { this.m = m; }
        }

        /// <summary>
        /// метод для тестирования и передачи его в качестве делегата 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        static private float getNumber(randomssss r) 
        {
            return r.m; 
        }

        static void Main(string[] args)
        {
            List <randomssss> list = new List<randomssss>() {new randomssss(1), new randomssss(2), new randomssss(30), new randomssss(4)};
            Console.WriteLine($"Get max {list.GetMax<randomssss>(getNumber).m}");
            #endregion


            #region 2-5 task
            DocumentsReceiver documentsReceiver = new DocumentsReceiver();
            documentsReceiver.found += FileFound;
            documentsReceiver.StartReceiver(@"C:\gitHub\c_Sharp__Developer_Professional\ProfHomeWork7");
          
            #endregion

        }
        private static void FileFound(string message) => Console.WriteLine($"Файл  нашёл {message}");
       
        





    }
}
