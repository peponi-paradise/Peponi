using System.ComponentModel;

namespace Peponi.Math.Coordinates;

public class SphericalCoordinate : ICoordinate
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

    public SphericalCoordinate(double r, double theta, double phi)
    {
        R = r;
        Theta = theta;
        Phi = phi;
    }

    public void Deconstruct(out double r, out double theta, out double phi)
    {
        r = R;
        theta = Theta;
        phi = Phi;
    }

    public double GetDistanceFromOrigin()
    {
        return R;
    }

    public override string ToString()
    {
        return $"{R}, {Theta}, {Phi}";
    }
}