using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork1.Models
{
    /// <summary>
    /// Детали заказа
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// Основной ключ
        /// </summary>
        [Key]//Первичный ключ
        public int OrderDetailID { get; set; }
      
        /// <summary>
        /// Количество
        /// </summary>
        public double Quantity { get; set; }
      
        /// <summary>
        /// Общая стоимость
        /// </summary>
        public double TotalCost { get; set; }

        ///// <summary>
        ///// Внешний ключ
        ///// </summary>
        public ICollection<Product> ProductID { get; set; } // может быть n заказов

        ///// <summary>
        ///// Внешний ключ
        ///// </summary>
        public virtual Order OrderID { get; set; } // Навигационное свойство

      //  public virtual Product Product { get; set; }
    }

}
