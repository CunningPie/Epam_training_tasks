using Ardalis.GuardClauses;
using System;

namespace GeometricShapesLibrary
{
    /// <summary>
    /// Класс круга.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Радиус.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Базовый конструктор класса Circle.
        /// </summary>
        public Circle(Point originCoord, double radius)
        {
            Guard.Against.NegativeOrZero(radius, nameof(radius));

            Radius = radius;
            OriginCoords = originCoord;
        }

        /// <summary>
        /// Перегрузка метода Shape.Area() для круга.
        /// </summary>
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Перегрузка метода Shape.Perimeter() для круга.
        /// </summary>
        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
