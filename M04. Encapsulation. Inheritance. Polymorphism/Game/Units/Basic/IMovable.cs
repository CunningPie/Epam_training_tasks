using System.Collections.Generic;

namespace Game.Units.Basic
{
    /// <summary>
    /// Интерфейс двигающихся объектов.
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// Перемещает юнита на новую позицию из списка positions за ход.
        /// </summary>
        public Position TurnMove(List<Position> positions, Position playerPos);

        /// <summary>
        /// Выбирает свободную позицию из списка positions при ходе в сторону игрока.
        /// </summary>
        /// <param name="positions"> Список свободных позиций для юнита. </param>
        /// <param name="playerPos"> Позиция игрока. </param>
        public Position MoveToPlayer(List<Position> positions, Position playerPos);

        /// <summary>
        /// Выбирает случайную позицию из доступных в списке positions.
        /// </summary>
        public Position Roam(List<Position> position);
    }
}
