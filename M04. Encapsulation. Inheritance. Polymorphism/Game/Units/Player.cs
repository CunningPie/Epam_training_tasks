using Game.Units.Basic;

namespace Game.Units
{
    /// <summary>
    /// Класс объекта игрока.
    /// </summary>
    public class Player : Unit
    {
        /// <summary>
        /// Базовый конструктор класса Player.
        /// </summary>
        public Player(int posX, int posY) : base(new(posX, posY), 'P')
        {
        }

        /// <summary>
        /// Перемещает игрока на новую позицию newPos.
        /// </summary>
        public void Move(Position pos)
        {
            Position.ChangePos(pos);
        }
    }
}
