using System.ComponentModel;

namespace Peponi.Maths.Coordinates;

/// <summary>
/// X, Y coordinates that support INotifyPropertyChanged
/// </summary>
public class CartesianCoordinate2D<T> : ICoordinate where T : struct
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

    public CartesianCoordinate2D()
    {
    }

    public CartesianCoordinate2D(T x, T y)
    {
        X = x;
        Y = y;
    }

    public void Deconstruct(out T x, out T y)
    {
        x = X;
        y = Y;
    }

    public double GetDistanceFromOrigin()
    {
        double x = Convert.ToDouble(X);
        double y = Convert.ToDouble(Y);
        return System.Math.Sqrt(x * x + y * y);
    }

    /// <summary>
    /// Get X, Y coordinates to string
    /// </summary>
    /// <returns>X, Y</returns>
    public override string ToString()
    {
        return $"{X}, {Y}";
    }
}