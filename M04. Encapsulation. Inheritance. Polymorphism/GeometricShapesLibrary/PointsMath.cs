using System;

namespace GeometricShapesLibrary
{
    /// <summary>
    /// Класс математики для типа Point.
    /// </summary>
    public static class PointsMath
    {
        /// <summary>
        /// Вычисляет длину отрезка между точками 'A' и 'B'.
        /// </summary>
        public static double Length(Point pointA, Point pointB)
        {
            return Math.Sqrt(
                   Math.Pow((pointA.X - pointB.X), 2)
                   + Math.Pow((pointA.Y - pointB.Y), 2)
                   );
        }
    }
}
