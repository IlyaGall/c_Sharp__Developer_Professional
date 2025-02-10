using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork4
{
    public abstract class ModelCar : IMyCloneable<ModelCar>, ICloneable
    {
        /// <summary>
        /// Название машины
        /// </summary>
        public string NameCar { get; set; }
       
        /// <summary>
        /// Цена машины
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Цвет машины
        /// </summary>
        public string Color { get; set; }
        protected ModelCar(string name, double price, string color)
        {
            NameCar = name;
            Price = price;
            Color = color;
        }

        /// <summary>
        /// Реализация IMyCloneable
        /// </summary>
        /// <returns></returns>
        public abstract ModelCar Clone();

        /// <summary>
        /// Реализация ICloneable
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
