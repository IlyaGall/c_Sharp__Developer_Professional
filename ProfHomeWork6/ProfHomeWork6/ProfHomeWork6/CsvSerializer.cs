using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork6
{
    internal class CsvSerializer
    {
        /// <summary>
        /// Сериализировать объект
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="obj">Объект</param>
        /// <returns>CSV текст</returns>
        public static string Serialize<T>(T obj)
        {
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            var values = new List<string>();

            // Собираем значения свойств
            foreach (var property in properties)
            {
                values.Add(property.GetValue(obj)?.ToString() ?? "");
            }

            // Собираем значения полей
            foreach (var field in fields)
            {
                values.Add(field.GetValue(obj)?.ToString() ?? "");
            }

            return string.Join(",", values);
        }
        /// <summary>
        ///  Десериализация CSV-строки в объект
        /// </summary>
        /// <param name="csv">строка csv</typeparam>
        /// <returns>Объект</returns>
        public static T Deserialize<T>(string csv) where T : new()
        {
            var type = typeof(T);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

            var values = csv.Split(',');

            var obj = new T();
            int index = 0;

            // Устанавливаем значения свойств
            foreach (var property in properties)
            {
                if (index >= values.Length) break;

                var value = Convert.ChangeType(values[index], property.PropertyType);
                property.SetValue(obj, value);
                index++;
            }

            // Устанавливаем значения полей
            foreach (var field in fields)
            {
                if (index >= values.Length) break;

                var value = Convert.ChangeType(values[index], field.FieldType);
                field.SetValue(obj, value);
                index++;
            }
            return obj;
        }
    }
}
