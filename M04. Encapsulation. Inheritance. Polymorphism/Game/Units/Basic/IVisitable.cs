namespace Game.Units.Basic
{
    /// <summary>
    /// Интерфейс объектов, которые можно посетить.
    /// </summary>
    public interface IVisitable
    {
        /// <summary>
        /// Метод, вызываемый при посещении клетки с юнитом, реализующим IVisitable.
        /// </summary>
        public int Visit();
    }
}
