using ProfHomeWork5.Interfaces;

namespace ProfHomeWork5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var settings = new Settings(5, 1, 100);
            IGame game = new Game(settings);
            game.Start();
        }
    }
}
