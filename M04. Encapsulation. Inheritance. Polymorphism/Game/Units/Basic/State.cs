using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Units.Basic
{
    /// <summary>
    /// Состояние клетки игровой карты.
    /// </summary>
    public enum State
    {
        Empty,
        Visitable,
        Obstacle,
        Player
    }
}
