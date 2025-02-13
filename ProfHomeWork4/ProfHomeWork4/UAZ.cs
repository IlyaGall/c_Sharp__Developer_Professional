using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork4
{
    public class UAZ : Jeep
    {
        /// <summary>
        /// наличия шноркеля 
        /// </summary>
        public bool Snorkel { get; set; }


        public UAZ(string name, double price, string color, bool downshift, bool snorkel)
            : base( name,  price,  color,  downshift, snorkel)
        {
            Snorkel = snorkel;
        }

        public override Jeep Clone()
        {
            return new UAZ(NameCar, Price, Color, Downshift, Snorkel);
        }
    }
}
