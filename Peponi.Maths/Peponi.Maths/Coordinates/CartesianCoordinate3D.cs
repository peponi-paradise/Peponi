using System.ComponentModel;

namespace Peponi.Maths.Coordinates;

/// <summary>
/// X, Y, Z coordinates that support INotifyPropertyChanged
/// </summary>
public class CartesianCoordinate3D<T> : ICoordinate where T : struct
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private T _x;

    public T X
    {
        get => _x;
        set
        {
            _x = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(X)));
        }
    }

    private T _y;

    public T Y
    {
        get => _y;
        set
        {
            _y = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Y)));
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

    public CartesianCoordinate3D()
    {
    }

    public CartesianCoordinate3D(T x, T y, T z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public void Deconstruct(out T x, out T y, out T z)
    {
        x = X;
        y = Y;
        z = Z;
    }

    public double GetDistanceFromOrigin()
    {
        double x = Convert.ToDouble(X);
        double y = Convert.ToDouble(Y);
        double z = Convert.ToDouble(Z);
        return System.Math.Sqrt(x * x + y * y + z * z);
    }

    /// <summary>
    /// Get X, Y, Z coordinates to string
    /// </summary>
    /// <returns>X, Y, Z</returns>
    public override string ToString()
    {
        return $"{X}, {Y}, {Z}";
    }
}