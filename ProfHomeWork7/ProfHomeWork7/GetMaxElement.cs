using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfHomeWork7
{
    public static class GetMaxElement
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            float max = 0;
            T maxItemElement = null;
            foreach (var item in collection)
            {
                float temp = convertToNumber(item);
                if (max < temp)
                {
                    max = temp;
                    maxItemElement = item;
                }
            }
            return maxItemElement;
        }
    }
}
