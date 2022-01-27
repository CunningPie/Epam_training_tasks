using Ardalis.GuardClauses;
using System;

namespace GeometricShapesLibrary
{
    /// <summary>
    /// Класс эллипса.
    /// </summary>
    public class Ellipse : Circle
    {
        /// <summary>
        /// Радиус 'B' эллипса.
        /// </summary>
        public double RadiusB { get; }

        /// <summary>
        /// Базовый конструктор класса Ellipse.
        /// </summary>
        public Ellipse(Point originCoords, double radiusA, double radiusB) : base(originCoords, radiusA)
        {
            Guard.Against.NegativeOrZero(radiusB, nameof(radiusB));

            RadiusB = radiusB;
        }

        /// <summary>
        /// Перегрузка метода Shape.Area() для эллипса.
        /// </summary>
        public override double Area()
        {
            return Math.PI * Radius * RadiusB;
        }

        /// <summary>
        /// Перегрузка метода Shape.Perimeter() для эллипса.
        /// </summary>
        public override double Perimeter()
        {
            return Math.PI * (3 * (Radius + RadiusB)
                   - Math.Sqrt((3 * Radius + RadiusB) * (Radius + 3 * RadiusB)));
        }
    }
}
