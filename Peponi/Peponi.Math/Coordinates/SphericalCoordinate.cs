using Peponi.Core.Interfaces;
using System.ComponentModel;

namespace Peponi.Math.Coordinates
{
    public class SphericalCoordinate : ICoordinate
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double _rho;

        public double Rho
        {
            get => _rho;
            set
            {
                _rho = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rho)));
            }
        }

        private double _theta;

        public double Theta
        {
            get => _theta;
            set
            {
                _theta = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Theta)));
            }
        }

        private double _phi;

        public double Phi
        {
            get => _phi;
            set
            {
                _phi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Phi)));
            }
        }

        public SphericalCoordinate()
        {
        }

        public SphericalCoordinate(double rho, double theta, double phi)
        {
            Rho = rho;
            Theta = theta;
            Phi = phi;
        }

        public void Deconstruct(out double rho, out double theta, out double phi)
        {
            rho = Rho;
            theta = Theta;
            phi = Phi;
        }

        public double GetDistanceFromOrigin()
        {
            return Rho;
        }

        public override string ToString()
        {
            return $"{Rho}, {Theta}, {Phi}";
        }
    }
}