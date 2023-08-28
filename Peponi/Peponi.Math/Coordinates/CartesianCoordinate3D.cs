using Peponi.Core.Interfaces;
using System.ComponentModel;

namespace Peponi.Math.Coordinates
{
    public class CartesianCoordinate3D : ICoordinate
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

        private double _z;

        public double Z
        {
            get => _z;
            set
            {
                _z = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Z)));
            }
        }

        public CartesianCoordinate3D()
        {
        }

        public CartesianCoordinate3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Deconstruct(out double x, out double y, out double z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        public double GetDistanceFromOrigin()
        {
            return System.Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }
    }
}