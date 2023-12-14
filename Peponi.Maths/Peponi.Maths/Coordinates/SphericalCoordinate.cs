using System.ComponentModel;

namespace Peponi.Maths.Coordinates;

/// <summary>
/// R, Theta, Phi coordinates that support INotifyPropertyChanged
/// </summary>
/// <remarks>
/// <see href="https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.Maths/Peponi.Maths/Docs/README.md"/>
/// </remarks>
public class SphericalCoordinate<T> : ICoordinate where T : struct
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

    private T _phi;

    public T Phi
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

    public SphericalCoordinate(T r, T theta, T phi)
    {
        R = r;
        Theta = theta;
        Phi = phi;
    }

    public void Deconstruct(out T r, out T theta, out T phi)
    {
        r = R;
        theta = Theta;
        phi = Phi;
    }

    public double GetDistanceFromOrigin()
    {
        return Convert.ToDouble(R);
    }

    /// <summary>
    /// Get R, Theta, Phi coordinates to string
    /// </summary>
    /// <returns>R, Theta, Phi</returns>
    public override string ToString()
    {
        return $"{R}, {Theta}, {Phi}";
    }
}