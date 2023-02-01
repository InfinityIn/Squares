namespace Squares
{
    public interface ISquareable
    {
        public double Square();
    }

    public class Circle : ISquareable 
    {
        readonly double _radius;
        public Circle(double radius)
        {
            ThrowIfIncorrect(radius);
            _radius = radius;            
        }
        public void ThrowIfIncorrect(double radius)
        {
            if(radius <= 0)
                throw new Exception($"Круг с радиусом {radius} не может существовать");
        }
        public double Square() => Math.Round(Math.PI * Math.Pow(_radius, 2),2);        
    }

    public class Triangle : ISquareable
    {
        readonly double _firstSide;
        readonly double _secondSide;
        readonly double _thirdSide;
        
        private double Hypotenuze;
        private double SemiPerimeter
        {
            get { return (_firstSide + _secondSide + _thirdSide) / 2; }
        }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            ThrowIfIncorrect(firstSide, secondSide, thirdSide);
            _firstSide = firstSide;
            _secondSide = secondSide;
            _thirdSide = thirdSide;
        }

        public void ThrowIfIncorrect(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
                throw new Exception("Некорректные значения длин сторон треугольника");
            if (firstSide >= secondSide + thirdSide
                || secondSide >= firstSide + thirdSide
                || thirdSide >= firstSide + secondSide)
                throw new Exception($"Треугольник со сторонами {firstSide}; {secondSide}; {thirdSide} не может существовать");
        }
        
        public bool IsRectangular()
        {
            if (_firstSide* _firstSide == _secondSide * _secondSide + _thirdSide * _thirdSide)
            {
                Hypotenuze = 1;
                return true;
            }
            if (_secondSide * _secondSide == _firstSide * _firstSide + _thirdSide * _thirdSide)
            {
                Hypotenuze = 2;
                return true;
            }
            if (_thirdSide * _thirdSide == _firstSide * _firstSide + _secondSide * _secondSide)
            {
                Hypotenuze = 3;
                return true;
            }
            return false;
        }


        public double Square()
        {
            double result = 0;
            if (this.IsRectangular())
                result = Hypotenuze switch
                {
                    1 => _secondSide * _thirdSide / 2,
                    2 => _firstSide * _thirdSide / 2,
                    3 => _firstSide * _secondSide / 2,
                };
            else
                result = Math.Sqrt(SemiPerimeter *
                            (SemiPerimeter - _firstSide) *
                            (SemiPerimeter - _secondSide) *
                            (SemiPerimeter - _thirdSide));
            return Math.Round(result, 2);
        }
            
    }
}