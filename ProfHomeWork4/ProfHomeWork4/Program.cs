namespace ProfHomeWork4
{
    internal class Program
    {
        /*
         * Создать иерархию из нескольких классов, в которых реализованы методы клонирования объектов по шаблону проектирования "Прототип".
            Описание/Пошаговая инструкция выполнения домашнего задания:
            Придумать и создать 3-4 класса, которые как минимум дважды наследуются и написать краткое описание текстом.
            Создать свой дженерик интерфейс IMyCloneable для реализации шаблона "Прототип".
            Сделать возможность клонирования объекта для каждого из этих классов, используя вызовы родительских конструкторов.
            Составить тесты или написать программу для демонстрации функции клонирования.
            Добавить к каждому классу реализацию стандартного интерфейса ICloneable и реализовать его функционал через уже созданные методы.
            Написать вывод: какие преимущества и недостатки у каждого из интерфейсов: IMyCloneable и ICloneable.

            Критерии оценки:
            2 балла: есть краткое описание созданных классов;
            2 балла: реализован шаблон проектирования Prototype с пользовательским интерфейсом;
            2 балла: реализован шаблон проектирования Prototype со стандартным интерфейсом;
            1 балла: созданы тесты/написано тестирование функционала;
            2 балла: написан вывод о преимуществах и недостатках каждого метода;
            1 балл: соблюдение CodeStyle, грамотная архитектура, всё замечания проверяющего исправлены.

Минимальный проходной балл: 8 баллов.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }public abstract class Animal : IMyCloneable<Animal>, ICloneable
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
}
