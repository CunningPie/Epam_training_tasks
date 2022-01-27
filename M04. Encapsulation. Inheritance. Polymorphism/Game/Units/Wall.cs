using Game.Units.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Units
{
    /// <summary>
    /// Класс препятствия Wall.
    /// </summary>
    public class Wall : Unit
    {
        /// <summary>
        /// Базовый конструктор класса Wall
        /// </summary>
        public Wall(Position pos) : base(pos, '#')
        {
        }
    }
}
