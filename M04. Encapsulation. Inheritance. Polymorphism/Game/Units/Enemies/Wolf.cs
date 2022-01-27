using Game.Units.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Units
{
    /// <summary>
    /// Класс врага Wolf.
    /// </summary>
    public class Wolf : Unit, IMovable, IVisitable
    {
        /// <summary>
        /// Базовый конструктор класса Wolf.
        /// </summary>
        public Wolf(Position newPos) : base(newPos, 'W')
        {
        }

        /// <summary>
        /// Реализация метода IMovable.MoveToPlayer для класса Wolf.
        /// </summary>
        public Position MoveToPlayer(List<Position> positions, Position playerPos)
        {
            positions.Sort(playerPos);
            return positions[0];
        }

        /// <summary>
        /// Реализация метода IMovable.Roam для класса Wolf.
        /// </summary>
        public Position Roam(List<Position> positions)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            return positions[random.Next() % positions.Count];
        }

        /// <summary>
        /// Реализация метода IMovable.TurnMove для класса Wolf.
        /// </summary>
        public Position TurnMove(List<Position> positions, Position playerPos)
        {
            if (Math.Abs(playerPos.PosX - Position.PosX) < 5 || Math.Abs(playerPos.PosY - Position.PosY) < 5)
            {
                Position.ChangePos(MoveToPlayer(positions, playerPos));
            }
            else
            {
                Position.ChangePos(Roam(positions));
            }

            return Position;
        }

        /// <summary>
        /// Реализация интерфейса IVisitable для класса Wolf.
        /// </summary>
        public int Visit()
        {
            return -1;
        }
    }
}
