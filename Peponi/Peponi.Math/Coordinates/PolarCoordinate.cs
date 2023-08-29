using Peponi.Core.Interfaces;
using System.ComponentModel;

namespace Peponi.Math.Coordinates;

public class PolarCoordinate : ICoordinate
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private double _r;

    public double R
    {
        get => _r;
        set
        {
            _r = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(R)));
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

    public PolarCoordinate()
    {
    }

    public PolarCoordinate(double r, double theta)
    {
        R = r;
        Theta = theta;
    }

    public void Deconstruct(out double r, out double theta)
    {
        r = R;
        theta = Theta;
    }

    public double GetDistanceFromOrigin()
    {
        return R;
    }

    public override string ToString()
    {
        return $"{R}, {Theta}";
    }
}