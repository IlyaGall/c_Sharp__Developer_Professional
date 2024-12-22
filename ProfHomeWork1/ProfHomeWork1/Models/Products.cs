using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork1.Models
{
    /// <summary>
    /// Таблица продуктов
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Основной ключ
        /// </summary>
        [Key]//Первичный ключ
        public int ProductID { get; set; }

        /// <summary>
        /// Название продукта
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Количество на складе
        /// </summary>
        public double QuantityInStock { get; set; }
    }

}
