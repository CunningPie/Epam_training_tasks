using Game.Units.Basic;

namespace Game.Units
{
    /// <summary>
    /// Класс бонуса Apple.
    /// </summary>
    public class Apple : Unit, IVisitable
    {
        /// <summary>
        /// Базовый конструктор класса Apple.
        /// </summary>
        public Apple(Position newPos) : base(newPos, 'A')
        {
        }

        /// <summary>
        /// Реализация интерфейса IVisitable для класса Apple.
        /// </summary>
        public int Visit()
        {
            return 50;
        }
    }
}
