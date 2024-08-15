using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public static class MyExtensions
    {
        public static T? GetMax<T>(this IEnumerable collection, Func<T, long> convertToNumber) where T : class
        {
            T? maxItem = default;
            long lastNumber = 0;
            foreach (var item in collection)
            {
                var currentNumber = convertToNumber.Invoke((T)item);
                if (currentNumber > lastNumber)
                {
                    maxItem = item as T;
                    lastNumber = currentNumber;
                }
            }
            return maxItem;
        }
    }
}
