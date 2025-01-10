using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        /// <param name="imitationimitationOfLongWork">Выполнить иммитацию долгой работы метода</param>
        /// <returns>Количество пробелов в файле</returns>
        /// <exception cref="Exception">Файла нет по указанному пути</exception>
        static public int GetSpace(string filePath, bool imitationimitationOfLongWork=false) 
        {
            if(imitationimitationOfLongWork) 
            { 
                Thread.Sleep(5000); 
            }
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
        /// Получить количество пробелов у файлов, которые находятся в папке
        /// </summary>
        /// <param name="pathDir">Путь к папке</param>
        /// <returns>Строка в которой отображено количество пробеллов с различными данными</returns>
        public static async Task<string> GetSpaceInFolder(string pathDir) 
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            StringBuilder resultTaskSpace = new StringBuilder();
            var cts = new CancellationTokenSource();
            List<Task<int>> tasks = new List<Task<int>>();
            var listFile = Directory.GetFiles(pathDir).Where(s => s.EndsWith(".txt"));
            
            foreach (var item in listFile)
            {
                tasks.Add(Task.Run(() =>
                     NumberOfSpaces.GetSpace(item)));
            }
            int[] results = await Task.WhenAll(tasks);

           
            for (int i = 0; i < results.Length; i++) 
            {
                resultTaskSpace.AppendLine($"File:{i} space: {results[i].ToString()}");
            }
            resultTaskSpace.AppendLine($"Result spece all file {results.Sum()}");
            stopwatch.Stop();
            resultTaskSpace.AppendLine($"Time to complete the task of counting spaces in a folder: {stopwatch}");
            return resultTaskSpace.ToString();
        }
    }
}
