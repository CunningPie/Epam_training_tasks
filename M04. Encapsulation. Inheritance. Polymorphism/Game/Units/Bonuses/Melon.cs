using Game.Units.Basic;

namespace Game.Units
{
    /// <summary>
    /// Класс бонуса Melon.
    /// </summary>
    public class Melon : Unit, IVisitable
    {
        /// <summary>
        /// Базовый конструктор класса Melon.
        /// </summary>
        public Melon(Position newPos) : base(newPos, 'M')
        {
        }

        /// <summary>
        /// Реализация интерфейса IVisitable для класса Melon.
        /// </summary>
        public int Visit()
        {
            return 100;
        }
    }
}
