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


    public abstract class Animal : IMyCloneable<Animal>, ICloneable
    {
        public string Name { get; set; }

        protected Animal(string name)
        {
            Name = name;
        }

        // Реализация IMyCloneable
        public abstract Animal Clone();

        // Реализация ICloneable
        object ICloneable.Clone()
        {
            return Clone();
        }
    }

    // Класс млекопитающего
    public class Mammal : Animal
    {
        public int Legs { get; set; }

        public Mammal(string name, int legs) : base(name)
        {
            Legs = legs;
        }

        public override Animal Clone()
        {
            return new Mammal(Name, Legs);
        }
    }

    // Класс птицы
    public class Bird : Animal
    {
        public double WingSpan { get; set; }

        public Bird(string name, double wingSpan) : base(name)
        {
            WingSpan = wingSpan;
        }

        public override Animal Clone()
        {
            return new Bird(Name, WingSpan);
        }
    }

    // Конкретный класс собаки
    public class Dog : Mammal
    {
        public string Breed { get; set; }

        public Dog(string name, int legs, string breed) : base(name, legs)
        {
            Breed = breed;
        }

        public override Animal Clone()
        {
            return new Dog(Name, Legs, Breed);
        }
    }

    // Конкретный класс орла
    public class Eagle : Bird
    {
        public string Type { get; set; }

        public Eagle(string name, double wingSpan, string type) : base(name, wingSpan)
        {
            Type = type;
        }

        public override Animal Clone()
        {
            return new Eagle(Name, WingSpan, Type);
        }
    }
}
