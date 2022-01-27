using Ardalis.GuardClauses;

namespace GeometricShapesLibrary
{
    /// <summary>
    /// Класс квадрата.
    /// </summary>
    public class Square : Shape
    {
        /// <summary>
        /// Ширина.
        /// </summary>
        public double Width { get; init; }

        /// <summary>
        /// Базовый конструктор класса Square.
        /// </summary>
        public Square(Point originCoords, double width)
        {
            Guard.Against.NegativeOrZero(width, nameof(width));

            OriginCoords = originCoords;
            Width = width;
        }

        /// <summary>
        /// Перегрузка метода Shape.Area() для квадрата.
        /// </summary>
        public override double Area()
        {
            return Width * Width;
        }

        /// <summary>
        /// Перегрузка метода Shape.Perimeter() для квадрата.
        /// </summary>
        public override double Perimeter()
        {
            return Width * 4;
        }
    }
}
