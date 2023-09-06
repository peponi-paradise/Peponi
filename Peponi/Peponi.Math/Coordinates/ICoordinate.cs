using System.ComponentModel;

namespace Peponi.Math.Coordinates;

public interface ICoordinate : INotifyPropertyChanged
{
    double GetDistanceFromOrigin();

    string ToString();
}