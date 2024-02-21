using System.ComponentModel;

namespace Peponi.Maths.Coordinates;

public interface ICoordinate : INotifyPropertyChanged
{
    double GetDistanceFromOrigin();

    string ToString();
}