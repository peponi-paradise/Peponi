using System.ComponentModel;

namespace Peponi.Math.Coordinates;

public class CylindricalCoordinate : ICoordinate
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

    public CylindricalCoordinate()
    {
    }

    public CylindricalCoordinate(double r, double theta, double z)
    {
        R = r;
        Theta = theta;
        Z = z;
    }

    public void Deconstruct(out double r, out double theta, out double z)
    {
        r = R;
        theta = Theta;
        z = Z;
    }

    public double GetDistanceFromOrigin()
    {
        return System.Math.Sqrt(R * R + Z * Z);
    }

    public override string ToString()
    {
        return $"{R}, {Theta}, {Z}";
    }
}