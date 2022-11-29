using System;

namespace Area
{
    public class Triangle : Figure, IFigure
    {
        private double _a;
        public double A
        {
            get => _a;
            set
            {
                if (value <= 0)
                    throw new FigureNotExistException("Side of a triangle cannot be negative or zero");
                _a = value;
            }
        }
        
        private double _b;
        public double B
        {
            get => _b;
            set
            {
                if (value <= 0)
                    throw new FigureNotExistException("Side of a triangle cannot be negative or zero");
                _b = value;
            }
        }
        
        private double _c;
        public double C
        {
            get => _c;
            set
            {
                if (value <= 0)
                    throw new FigureNotExistException("Side of a triangle cannot be negative or zero");
                _c = value;
            }
        }
        
        public Triangle(){}
        public Triangle(double a, double b, double c)
        {
            if (a + b <= c || b + c <= a || a + c <= b)
                throw new FigureNotExistException("There is no triangle with such sides");
            A = a;
            B = b;
            C = c;
        }

        public double Area
        {
            get
            {
                double p = (_a + _b + _c) / 2;
                return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
            }
        }

        public bool IsRectangular => ((_a * _a + _b * _b == _c * _c) || (_a * _a + _c * _c == _b * _b) ||
                                      (_c * _c + _b * _b == _a * _a));
    }
}