using System.ComponentModel;

namespace Peponi.Maths.Coordinates;

/// <summary>
/// R, Theta, Z coordinates that support INotifyPropertyChanged
/// </summary>
public class CylindricalCoordinate<T> : ICoordinate where T : struct
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private T _r;

    public T R
    {
        get => _r;
        set
        {
            _r = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(R)));
        }
    }

    private T _theta;

    public T Theta
    {
        get => _theta;
        set
        {
            _theta = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Theta)));
        }
    }

    private T _z;

    public T Z
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

    public CylindricalCoordinate(T r, T theta, T z)
    {
        R = r;
        Theta = theta;
        Z = z;
    }

    public void Deconstruct(out T r, out T theta, out T z)
    {
        r = R;
        theta = Theta;
        z = Z;
    }

    public double GetDistanceFromOrigin()
    {
        double r = Convert.ToDouble(R);
        double z = Convert.ToDouble(Z);
        return System.Math.Sqrt(r * r + z * z);
    }

    /// <summary>
    /// Get R, Theta, Z coordinates to string
    /// </summary>
    /// <returns>R, Theta, Z</returns>
    public override string ToString()
    {
        return $"{R}, {Theta}, {Z}";
    }
}