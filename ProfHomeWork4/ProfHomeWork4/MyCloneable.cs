using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork4
{
    /// <summary>
    /// Интерфейс для клонирования Дженерик
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMyCloneable<T>
    {
        T Clone();
    }
}
