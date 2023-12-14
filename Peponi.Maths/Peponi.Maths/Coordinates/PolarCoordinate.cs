using System.ComponentModel;

namespace Peponi.Maths.Coordinates;

/// <summary>
/// R, Theta coordinates that support INotifyPropertyChanged
/// </summary>
/// <remarks>
/// <see href="https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.Maths/Peponi.Maths/Docs/README.md"/>
/// </remarks>
public class PolarCoordinate<T> : ICoordinate where T : struct
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

    public PolarCoordinate()
    {
    }

    public PolarCoordinate(T r, T theta)
    {
        R = r;
        Theta = theta;
    }

    public void Deconstruct(out T r, out T theta)
    {
        r = R;
        theta = Theta;
    }

    public double GetDistanceFromOrigin()
    {
        return Convert.ToDouble(R);
    }

    /// <summary>
    /// Get R, Theta coordinates to string
    /// </summary>
    /// <returns>R, Theta</returns>
    public override string ToString()
    {
        return $"{R}, {Theta}";
    }
}