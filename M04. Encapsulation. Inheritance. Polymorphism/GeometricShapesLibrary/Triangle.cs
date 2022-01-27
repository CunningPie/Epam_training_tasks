using System;

namespace GeometricShapesLibrary
{
    /// <summary>
    /// Класс треугольника.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Точка 'B' треугольника.
        /// </summary>
        public Point PointB { get; init; }

        /// <summary>
        /// Точка 'C' треугольника.
        /// </summary>
        public Point PointC { get; init; }

        /// <summary>
        /// Базовый конструктор класса Triangle.
        /// </summary>
        public Triangle(Point originCoords, Point pointB, Point pointC)
        {
            OriginCoords = originCoords;
            PointB = pointB;
            PointC = pointC;
        }

        /// <summary>
        /// Перегрузка метода Shape.Area() для треугольника.
        /// </summary>
        public override double Area()
        {
            double semiperimeter = Perimeter() / 2;

            return
                Math.Sqrt(semiperimeter
                * (semiperimeter - PointsMath.Length(OriginCoords, PointB))
                * (semiperimeter - PointsMath.Length(OriginCoords, PointC))
                * (semiperimeter - PointsMath.Length(PointB, PointC)));
        }

        /// <summary>
        /// Перегрузка метода Shape.Perimeter() для треугольника.
        /// </summary>
        public override double Perimeter()
        {
            return
                PointsMath.Length(OriginCoords, PointB)
                + PointsMath.Length(PointB, PointC)
                + PointsMath.Length(OriginCoords, PointC);
        }
    }
}
