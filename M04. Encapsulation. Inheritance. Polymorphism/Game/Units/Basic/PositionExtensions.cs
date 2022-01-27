using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Units.Basic
{
    /// <summary>
    /// Расширяет функционал класса Position методом сортировки позиций.
    /// </summary>
    public static class PositionExtension
    {
        /// <summary>
        /// Сортировка списка позиций по удаленности относительно цели.
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static void Sort(this List<Position> positions, Position target)
        {
            positions.Sort(new Comparison<Position>((x, y) => Math.Sign(Position.Distanse(x, target) - Position.Distanse(y, target))));
        }
    }
}
