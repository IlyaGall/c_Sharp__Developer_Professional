using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork5.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий настройки игры
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Максимальное кол-во попыток
        /// </summary>
        int MaxAttempts { get; }
        /// <summary>
        /// Начальное число (первая точка)
        /// </summary>
        int RangeStart { get; }
        /// <summary>
        /// Конечное число (последнее число)
        /// </summary>
        int RangeEnd { get; }
    }
}
