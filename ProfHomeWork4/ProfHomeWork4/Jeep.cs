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
    public class Jeep : ModelCar
    {
        /// <summary>
        /// Понижающая передача
        /// </summary>
        public bool Downshift { get; set; } =false;
        /// <summary>
        /// Межосевая блокировка
        /// </summary>
        public bool InteraxleLock { get; set; }
        public  Jeep(string name, double price, string color, bool downshift, bool interaxleLock)
            :base(name, price, color)
        {
            Downshift = downshift;
            InteraxleLock = interaxleLock;
        }
     
        public override ModelCar Clone()
        {
            return new Jeep(NameCar, Price, Color, Downshift, InteraxleLock);
        }
    }
}
