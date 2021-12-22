using System;
using Ardalis.GuardClauses;

namespace RectangleHelper
{
    /// <summary>
    /// Класс подсчета параметров прямоугольников.
    /// </summary>
    public static class RectangleMath
    {
        /// <summary>
        /// Метод, считающий периметр прямоугольника.
        /// </summary>
        public static double RectanglePerimeter(double width, double height)
        {
            Guard.Against.NegativeOrZero(width, "");
            Guard.Against.NegativeOrZero(height, "");

            return (width + height) * 2;
        }

        /// <summary>
        /// Метод, считающий площадь прямоугольника.
        /// </summary>
        public static double RectangleSquare(double width, double height)
        {
            Guard.Against.NegativeOrZero(width, "");
            Guard.Against.NegativeOrZero(height, "");

            return width * height;
        }
    }
}
