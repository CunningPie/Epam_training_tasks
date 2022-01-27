using System.Collections.Generic;
using Ardalis.GuardClauses;
using Game.Units;
using Game.Units.Basic;

namespace Game
{
    /// <summary>
    /// Класс игрового поля.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Ширина игрового поля.
        /// </summary>
        public int Width { get;  }

        /// <summary>
        /// Высота игрового поля.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Список препятствий на карте.
        /// </summary>
        public List<Unit> Obstacles { get; }

        /// <summary>
        /// Список двигающихся юнитов на карте.
        /// </summary>
        public List<IMovable> MovingUnits { get; }

        /// <summary>
        /// Список бонусов на карте.
        /// </summary>
        public List<Unit> Bonuses { get; }

        /// <summary>
        /// Базовый конструктор класса Field.
        /// </summary>
        public Field(int width, int height, List<Unit> obstacles, List<Unit> bonuses, List<IMovable> movingUnits)
        {
            Guard.Against.NegativeOrZero(width, nameof(width));
            Guard.Against.NegativeOrZero(height, nameof(height));
            Guard.Against.Null(obstacles, nameof(obstacles));
            Guard.Against.Null(bonuses, nameof(bonuses));
            Guard.Against.Null(movingUnits, nameof(movingUnits));

            Width = width;
            Height = height;
            Obstacles = obstacles;
            Bonuses = bonuses;
            MovingUnits = movingUnits;
        }

        /// <summary>
        /// Удаляет бонус с поля по позиции pos.
        /// Возвращает true если после удаления список бонусов Bonuses не пуст, false - иначе.
        /// </summary>
        public bool DeleteBonus(Position pos)
        {
            Unit delete = null;

            foreach (var bonus in Bonuses)
            {
                if (bonus.Position.Equals(pos))
                {
                    delete = bonus;
                }
            }

            Bonuses.Remove(delete);

            if (Bonuses.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}
