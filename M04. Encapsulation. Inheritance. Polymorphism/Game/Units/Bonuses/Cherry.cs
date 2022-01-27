using Game.Units.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Units
{
    /// <summary>
    /// Класс бонуса Cherry.
    /// </summary>
    public class Cherry : Unit, IVisitable
    {
        /// <summary>
        /// Базовый конструктор класса Cherry.
        /// </summary>
        public Cherry(Position newPos) : base(newPos, 'C')
        {
        }

        /// <summary>
        /// Реализация интерфейса IVisitable для класса Cherry.
        /// </summary>
        public int Visit()
        {
            return 150;
        }
    }
}
