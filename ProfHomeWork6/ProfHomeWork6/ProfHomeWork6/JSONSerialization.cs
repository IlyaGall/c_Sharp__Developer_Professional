using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtft = Newtonsoft.Json;

namespace ProfHomeWork6
{






  static  public class JSONSerialization
    {
        /// <summary>
        /// Сериализировать объект (System.Text.Json)
        /// </summary>
        /// <param name="classSerialization">Объект</param>
        /// <returns>Json в строки</returns>
        static public string Serialization<T>(T classSerialization) => JsonSerializer.Serialize(classSerialization);


        /// <summary>
        /// Сериализировать объект (System.Text.Json)
        /// </summary>
        /// <param name="classSerialization">Объект</param>
        /// <returns>Json в строки</returns>
        // static public string SerializationStatic(T classSerialization) => JsonSerializer.Serialize(classSerialization);

        /// <summary>
        /// Десерисализировать объект
        /// </summary>
        /// <param name="classSerialization">Тип в который нужно десериализировать объект</param>
        /// <param name="jsonText">Json тест</param>
        /// <returns>Объект</returns>
        static public T? Deserialization<T>(T classSerialization, string jsonText) => JsonSerializer.Deserialize<T>(jsonText);

        /// <summary>
        /// С использованием Newtonsoft.Json
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns>Json в строки</returns>
        static public string SerializationJsonConvert<T>(T obj) => Newtft.JsonConvert.SerializeObject(obj);


        /// <summary>
        /// С использованием Newtonsoft.Json
        /// </summary>
        /// <param name="jsonData">Объект</param>
        /// <returns>Json в строки</returns>
        static public T? DeserializationJsonConvert<T>( string jsonData) => Newtft.JsonConvert.DeserializeObject<T>(jsonData);


    }
}
