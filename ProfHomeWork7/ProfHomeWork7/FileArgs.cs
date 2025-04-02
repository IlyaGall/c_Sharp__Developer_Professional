using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork7
{

    public class FileArgs: EventArgs
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; } = string.Empty;
    
        public FileArgs(string fileName) 
        {
            FileName = getFileName(fileName);
        }

        /// <summary>
        /// Отделяет название файла от его пути
        /// </summary>
        /// <param name="pathFile">путь к файлу</param>
        /// <returns></returns>
        private string getFileName(string pathFile) 
        {
            string[] strings = pathFile.Split('\\');
            int length=strings.Length;
            if (length > 0) 
            {
                return strings[length-1];
            }
            return string.Empty;
        }
    }

}
