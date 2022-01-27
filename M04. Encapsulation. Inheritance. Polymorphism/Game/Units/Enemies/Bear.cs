using Game.Units.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Units
{
    /// <summary>
    /// Класс врага Bear.
    /// </summary>
    public class Bear : Unit, IMovable, IVisitable
    {
        /// <summary>
        /// Базовый конструктор класса Bear.
        /// </summary>
        public Bear(Position newPos) : base(newPos, 'B')
        {
        }

        /// <summary>
        /// Реализация метода IMovable.MoveToPlayer для класса Bear.
        /// </summary>
        public Position MoveToPlayer(List<Position> positions, Position playerPos)
        {
            positions.Sort(playerPos);
            return positions[0];
        }

        /// <summary>
        /// Реализация метода IMovable.Roam для класса Bear.
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
            if (Math.Abs(playerPos.PosX - Position.PosX) < 3 || Math.Abs(playerPos.PosY - Position.PosY) < 3)
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
        /// Реализация интерфейса IVisitable для класса Bear.
        /// </summary>
        public int Visit()
        {
            return -1;
        }
    }
}
