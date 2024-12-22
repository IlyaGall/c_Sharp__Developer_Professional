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
    /// Таблица пользователей
    /// </summary>
    public class User
    {
        /// <summary>
        /// Основной ключ
        /// </summary>
        [Key]//основной ключ
        public int UserID { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
       //[Required] //не null сделал через model в классе context
        public string UserName { get; set; }
        /// <summary>
        /// Электронная почта 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Дата регистрации  
        /// </summary>
        public DateTime RegistrationDate { get; set; }

    }
}
