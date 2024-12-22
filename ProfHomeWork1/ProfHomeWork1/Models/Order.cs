using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork1.Models
{

    /// <summary>
    /// Таблица Заказы
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Основной ключ
        /// </summary>
        [Key]//Первичный ключ
        public int OrderID { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Внешний ключ, указывающий на пользователя
        /// </summary>
        public int UserID { get; set; } 
       
        /// <summary>
        /// Связь с пользователем
        /// </summary>
        public virtual User User { get; set; } // у одного заказа один пользователь => 1:n

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
