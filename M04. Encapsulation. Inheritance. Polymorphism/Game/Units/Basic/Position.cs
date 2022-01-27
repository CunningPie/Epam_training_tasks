using Ardalis.GuardClauses;
using System;

namespace Game.Units.Basic
{
    /// <summary>
    /// Класс позиции юнита.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Позиция юнита по X.
        /// </summary>
        public int PosX { get; private set; }

        /// <summary>
        /// Позиция юнита по Y.
        /// </summary>
        public int PosY { get; private set; }

        /// <summary>
        /// Базовый конструктор класса Position.
        /// </summary>
        public Position(int posX, int posY)
        {
            Guard.Against.Negative(posX, nameof(posX));
            Guard.Against.Negative(posY, nameof(posY));

            PosX = posX;
            PosY = posY;
        }

        /// <summary>
        /// Меняет значение позиции юнита по координате X.
        /// </summary>
        public void ChangePosX(int posX)
        {
            Guard.Against.Negative(posX, nameof(posX));

            PosX = posX;
        }

        /// <summary>
        /// Меняет значение позиции юнита по координате Y.
        /// </summary>
        public void ChangePosY(int posY)
        {
            Guard.Against.Negative(posY, nameof(posY));

            PosY = posY;
        }

        /// <summary>
        /// Меняет значение позиции юнита.
        /// </summary>
        public void ChangePos(int posX, int posY)
        {
            ChangePosX(posX);
            ChangePosY(posY);
        }

        /// <summary>
        /// Меняет значение позиции юнита.
        /// </summary>
        public void ChangePos(Position pos)
        {
            Guard.Against.Null(pos, nameof(pos));

            ChangePosX(pos.PosX);
            ChangePosY(pos.PosY);
        }

        /// <summary>
        /// Генерирует случайную позицию в области width x height.
        /// </summary>
        public static Position GenerateRandomPos(int width, int height)
        {
            Guard.Against.NegativeOrZero(width, nameof(width));
            Guard.Against.NegativeOrZero(height, nameof(height));

            Random rand = new Random((int)DateTime.Now.Ticks);

            return new Position(rand.Next() % width, rand.Next() % height);
        }

        /// <summary>
        /// Возвращает расстояние между двумя позициями.
        /// </summary>
        public static double Distanse(Position posA, Position posB)
        {
            return Math.Sqrt(
                   Math.Pow(posA.PosX - posB.PosX, 2)
                   + Math.Pow(posA.PosY - posB.PosY, 2)
                   );
        }

        /// <summary>
        /// Перегрузка метода Equals.
        /// </summary>
        public override bool Equals(object obj)
        {
            return
                PosX == (obj as Position).PosX
                && PosY == (obj as Position).PosY;
        }

        /// <summary>
        /// Перегрузка метода GetHashCode.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
