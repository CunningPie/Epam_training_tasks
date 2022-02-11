using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M07_Delegates_Lambdas_and_Events
{
    /// <summary>
    /// Интерфейс сортировки.
    /// </summary>
    internal interface IRowsSorter
    {
        /// <summary>
        /// Сортирует строки массива указанным способом.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="asc">Флаг сортировки по возрастанию/убыванию.</param>
        public void Sort(int [,] arr, bool asc);
    }
}
