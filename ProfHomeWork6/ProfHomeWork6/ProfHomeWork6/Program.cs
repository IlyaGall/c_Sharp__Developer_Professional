using System.Diagnostics;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace ProfHomeWork6
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int countStep = 100000;
            ClassF obj = new ClassF().Get();
            ReflectionJson(obj, countStep);
            JsonSerializer(obj, countStep);
            JsonNewtonsoftJson(obj, countStep);
        }

        static private void ReflectionJson(ClassF obj, int countStep)
        {

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < countStep; i++)
            {
                string csv = CsvSerializer.Serialize(obj);
            }
            stopwatch.Stop();
            Console.WriteLine($"Время на сериализацию (Reflection): {stopwatch.ElapsedMilliseconds} мс");
            stopwatch.Reset();

            // Замер времени десериализации
            var csvData = CsvSerializer.Serialize(obj);
            stopwatch.Restart();
            for (int i = 0; i < countStep; i++)
            {
                ClassF newObj = CsvSerializer.Deserialize<ClassF>(csvData);
            }
            stopwatch.Stop();
            Console.WriteLine($"Время на десериализацию (Reflection): {stopwatch.ElapsedMilliseconds} мс");
            stopwatch.Reset();


        }
        
        static private void JsonSerializer(ClassF obj, int countStep)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < countStep; i++)
            {
                string json = JSONSerialization.Serialization<ClassF>(obj);
            }
            stopwatch.Stop();
            Console.WriteLine($"Время с базового сериализатора (JsonSerializer) {stopwatch.ElapsedMilliseconds} мс");
            stopwatch.Reset();

            stopwatch.Start();

            string json1 = JSONSerialization.Serialization<ClassF>(obj);
            for (int i = 0; i < countStep; i++)
            {
                ClassF deser1 = JSONSerialization.Deserialization<ClassF>(obj, json1);
            }
            stopwatch.Stop();
            Console.WriteLine($"Время с базового десериализатора (JsonSerializer) {stopwatch.ElapsedMilliseconds} мс");
            stopwatch.Reset();

        }

        static private void JsonNewtonsoftJson(ClassF obj, int countStep)
        {
            Stopwatch stopwatch = new Stopwatch();
            // Сериализация с помощью Newtonsoft.Json
            stopwatch.Restart();
            for (int i = 0; i < countStep; i++)
            {
                var json = JSONSerialization.SerializationJsonConvert<ClassF>(obj);
            }
            stopwatch.Stop();
            Console.WriteLine($"Время на сериализацию (Newtonsoft.Json): {stopwatch.ElapsedMilliseconds} мс");

            // Десериализация с помощью Newtonsoft.Json
            var jsonData = JsonConvert.SerializeObject(obj);
            stopwatch.Restart();
            for (int i = 0; i < countStep; i++)
            {
                var newObj = JSONSerialization.DeserializationJsonConvert<ClassF>(jsonData);
            }
            stopwatch.Stop();
            Console.WriteLine($"Время на десериализацию (Newtonsoft.Json): {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}
