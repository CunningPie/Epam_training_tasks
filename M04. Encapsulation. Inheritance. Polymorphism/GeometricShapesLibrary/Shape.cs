using System;

namespace GeometricShapesLibrary
{
    /// <summary>
    /// Абстрактный класс геометрической формы.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Координаты точки начала фигуры.
        /// </summary>
        public Point OriginCoords { get; set; }

        /// <summary>
        /// Абстрактный метод рассчета площади формы.
        /// </summary>
        public abstract double Area();

        /// <summary>
        /// Абстрактный метод рассчета периметра формы.
        /// </summary>
        public abstract double Perimeter();
    }
}
