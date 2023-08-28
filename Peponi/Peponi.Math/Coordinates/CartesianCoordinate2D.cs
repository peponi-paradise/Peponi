using Peponi.Core.Interfaces;
using System.ComponentModel;

namespace Peponi.Math.Coordinates
{
    public class CartesianCoordinate2D : ICoordinate
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _x;

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
            }
        }

        private double _y;

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
            }
        }

        public CartesianCoordinate2D()
        {
        }

        public CartesianCoordinate2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Deconstruct(out double x, out double y)
        {
            x = X;
            y = Y;
        }

        public double GetDistanceFromOrigin()
        {
            return System.Math.Sqrt(X * X + Y * Y);
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
}