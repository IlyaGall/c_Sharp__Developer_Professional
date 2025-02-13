using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProfHomeWork4
{
    public class Kamaz:Truck
    {
        /// <summary>
        /// Название модели камаза
        /// </summary>
        public string NameModel { get; set; }

        /// <summary>
        /// грузоподъемность грузовика
        /// </summary>
        public double TruckCapacity { get; set; }

        public Kamaz(string name, double price, string color, double downshift, string nameModel,double truckCapacity) 
            : base(name,  price,  color,  downshift)
        {
            NameModel = nameModel;
            TruckCapacity = truckCapacity;
        }

        public override Truck Clone()
        {
            return new Kamaz(NameCar,  Price,  Color, BodyCapacity,  NameModel, TruckCapacity);
        }
    }
}
