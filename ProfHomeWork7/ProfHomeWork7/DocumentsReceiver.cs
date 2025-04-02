using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork7
{
    /*
      2. Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла;
        3. Оформить событие и его аргументы с использованием .NET соглашений:
            * public event EventHandler FileFound;
            * FileArgs – будет содержать имя файла и наследоваться от EventArgs
        4. Добавить возможность отмены дальнейшего поиска из обработчика;
        5. Вывести в консоль сообщения, возникающие при срабатывании событий и результат поиска максимального элемента.
     */
    // http://metanit.com/sharp/tutorial/3.14.php
    /// <summary>
    /// Обойти директорию и получить файлы
    /// </summary>
    public class DocumentsReceiver
    {

        public event FileFoundEventHandler found;

        public delegate void FileFoundEventHandler(DocumentsReceiver sender, FileArgs e);

        /// <summary>
        /// Завершить обработку
        /// </summary>
        volatile public bool IsStop  = false;

        /// <summary>
        /// Поиск файлов
        /// </summary>
        /// <param name="dir">Путь к папке в которой нужно найти файлы</param>
        public void StartReceiver(string dir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    //обход файлов
                    found?.Invoke(this, new FileArgs(f));
                    if (IsStop) 
                    {
                        return;
                    }
                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    if (IsStop)
                    {
                        return;
                    }
                    //  обход папок
                    StartReceiver(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}
