using System.ComponentModel;

namespace Peponi.Core.Interfaces;

public interface ICoordinate : INotifyPropertyChanged
{
    double GetDistanceFromOrigin();

    string ToString();
}