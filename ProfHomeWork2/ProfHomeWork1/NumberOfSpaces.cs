using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork1
{
    internal class NumberOfSpaces
    {
        /// <summary>
        /// Метод для работы с файлом
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        static public int GetSpace(string filePath) 
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    return  reader.ReadToEnd().Count(x => x == ' ');
                }
            }
            else 
            {
                throw new Exception("Файла по указаному путь не существует");
            }
        }

        /// <summary>
        /// Получить колличество пробелов в файле
        /// </summary>
        /// <param name="path">Путь к папке</param>
        /// <returns></returns>
        public static  int GetSpaceInFolder(string path) 
        {
            Thread.Sleep(5000);
            return 0;
           // return  OpenTxtAndGetCountSpace(path);
           
        }
    }
}
