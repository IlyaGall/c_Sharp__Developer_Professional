using ProfHomeWork5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game : IGame
{
    private readonly ISettings _settings;
    private readonly Random _random;
    private int _numberToGuess;

    public Game(ISettings settings)
    {
        _settings = settings;
        _random = new Random();
        _numberToGuess = _random.Next(_settings.RangeStart, _settings.RangeEnd + 1);
    }

    public void Start()
    {
        Console.WriteLine($"Угадайте число от {_settings.RangeStart} до {_settings.RangeEnd}");

        for (int attempt = 1; attempt <= _settings.MaxAttempts; attempt++)
        {
            Console.Write("Введите ваше предположение: ");
            if (int.TryParse(Console.ReadLine(), out var guess))
            {
                if (guess == _numberToGuess)
                {
                    Console.WriteLine("Поздравляю! Вы угадали число!");
                    return;
                }
                else if (guess < _numberToGuess)
                {
                    Console.WriteLine("Больше.");
                }
                else
                {
                    Console.WriteLine("Меньше.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод, попробуйте ещё раз.");
            }
        }
        Console.WriteLine($"Вы исчерпали все попытки. Загаданное число было {_numberToGuess}.");
    }
}
