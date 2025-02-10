using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork4
{
    public class Truck:ModelCar
    {
        /// <summary>
        /// Объём кузова
        /// </summary>
        public double BodyCapacity { get; set; } 
     
        public Truck(string name, double price, string color, double bodyCapacity)
            : base(name, price, color)
        {
            BodyCapacity = bodyCapacity;
            
        }

        public override ModelCar Clone()
        {
            return new Truck(NameCar, Price, Color, BodyCapacity);
        }
    }
}
