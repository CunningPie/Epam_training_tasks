using Ardalis.GuardClauses;

namespace GeometricShapesLibrary
{
    /// <summary>
    /// Класс прямоугольника.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Высота прямоугольника.
        /// </summary>
        public double Height { get; init; }

        /// <summary>
        /// Ширина прямоугольника.
        /// </summary>
        public double Width { get; init; }

        /// <summary>
        /// Базовый конструктор класса Rectangle.
        /// </summary>
        public Rectangle(Point originCoords, double width, double height)
        {
            Guard.Against.NegativeOrZero(width, nameof(width));
            Guard.Against.NegativeOrZero(height, nameof(height));

            OriginCoords = originCoords;
            Height = height;
            Width = width;
        }

        /// <summary>
        /// Перегрузка метода Shape.Area() для прямоугольника.
        /// </summary>
        public override double Area()
        {
            return Width * Height;
        }

        /// <summary>
        /// Перегрузка метода Shape.Perimeter() для прямоугольника.
        /// </summary>
        public override double Perimeter()
        {
            return (Width + Height) * 2;
        }
    }
}
