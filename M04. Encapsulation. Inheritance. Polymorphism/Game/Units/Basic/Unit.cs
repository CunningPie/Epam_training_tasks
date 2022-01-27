using Ardalis.GuardClauses;

namespace Game.Units.Basic
{
    /// <summary>
    /// Абстрактный класс объекта.
    /// </summary>
    public abstract class Unit
    {
        /// <summary>
        /// Символ отрисовки юнита в консоли.
        /// </summary>
        public char Symbol { get; init; }

        /// <summary>
        /// Позиция юнита.
        /// </summary>
        public Position Position { get; private set; }

        /// <summary>
        /// Меняет позицию юнита.
        /// </summary>
        public void ChangePos(Position pos)
        {
            Position.ChangePos(pos);
        }

        /// <summary>
        /// Базовый конструктор класса Unit.
        /// </summary>
        public Unit(Position pos, char sym)
        {
            Guard.Against.Null(pos, nameof(pos));

            Position = pos;
            Symbol = sym;
        }
    }
}
