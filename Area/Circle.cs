using System;

namespace Area
{
    public class Circle : Figure, IFigure
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        private double _radius;
        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new FigureNotExistException("Radius cannot be negative or zero");
                _radius = value;
            }

        }

        public double Area => Math.PI * Math.Pow(Radius, 2);
    }
}