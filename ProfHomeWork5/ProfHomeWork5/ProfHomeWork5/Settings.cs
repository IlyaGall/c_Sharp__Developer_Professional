using ProfHomeWork5.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork5
{
    public class Settings : ISettings
    {
        public int MaxAttempts { get; private set; }
        public int RangeStart { get; private set; }
        public int RangeEnd { get; private set; }

        /// <summary>
        /// Настроить игру
        /// </summary>
        /// <param name="maxAttempts">Максимальное кличество попыток</param>
        /// <param name="rangeStart">Начальное число(Начало диапазона)</param>
        /// <param name="rangeEnd">Конечное число(Конец диапазона)</param>
        public Settings(int maxAttempts, int rangeStart, int rangeEnd)
        {
            MaxAttempts = maxAttempts;
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
        }
    }

}
