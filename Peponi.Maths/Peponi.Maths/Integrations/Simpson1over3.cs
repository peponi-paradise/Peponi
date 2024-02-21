using Peponi.Maths.Extensions;

namespace Peponi.Maths.Integration;

/// <summary>
/// Compute by Simpson's 1/3 rule.
/// </summary>
/// <remarks>
/// <see href="https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.Maths/Peponi.Maths/Docs/README.md"/>
/// </remarks>
public static class Simpson1over3
{
    /// <summary>
    /// <code>
    /// Compute by given params
    /// Convert values to double internally
    /// Count of xs and ys are should be equal
    /// Count of xs and ys are at least 3, odd number
    /// </code>
    /// </summary>
    /// <typeparam name="X">Struct type</typeparam>
    /// <typeparam name="Y">Struct type</typeparam>
    /// <param name="xs">Interval of xs should be uniform</param>
    /// <param name="ys"></param>
    /// <returns>Computed value</returns>
    /// <exception cref="ArgumentException"></exception>
    public static double Integrate<X, Y>(List<X> xs, List<Y> ys) where X : struct
                                                                            where Y : struct
    {
        List<double> _Xs;
        List<double> _Ys;
        if (xs.Count != ys.Count) throw new ArgumentException($"Input value count mismatched. xs : {xs.Count}, ys : {ys.Count}");
        else if (xs.Count < 3) throw new ArgumentException("Required at least 3 points");
        else if (!xs.Count.IsOdd()) throw new ArgumentException("Input array's count should be odd");
        else
        {
            _Xs = xs.Select(x => Convert.ToDouble(x)).ToList();
            _Ys = ys.Select(x => Convert.ToDouble(x)).ToList();
            if (!_Xs.IsIntervalUniform()) throw new ArgumentException("X axis array's interval should be uniform");
        }

        double sumOdd = 0;
        double sumEven = 0;
        double intervalH = (_Xs.Max() - _Xs.Min()) / (_Xs.Count - 1) / 3;

        for (int i = 1; i < _Ys.Count - 1; i++)
        {
            if (i.IsEven()) sumEven += _Ys[i];
            else sumOdd += _Ys[i];
        }

        sumOdd = 4 * sumOdd;
        sumEven = 2 * sumEven;

        double yTotal = _Ys[0] + _Ys[_Ys.Count - 1] + sumOdd + sumEven;
        double result = intervalH * yTotal;

        return result;
    }

    /// <summary>
    /// Compute by given function
    /// </summary>
    /// <param name="fx"></param>
    /// <param name="lowLimit">Low limit &lt; Upper limit</param>
    /// <param name="upperLimit">Low limit &lt; Upper limit</param>
    /// <param name="intervalCount">Count should be even</param>
    /// <returns>Computed value</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public static double Integrate(Func<double, double> fx, double lowLimit, double upperLimit, int intervalCount)
    {
        if (lowLimit > upperLimit) throw new ArgumentException($"Low limit ({lowLimit}) could not bigger than upper limit ({upperLimit})");
        else if (fx == null) throw new ArgumentNullException("fx is null");
        else if (intervalCount.IsOdd()) throw new ArgumentException("Interval count should be even");

        double deltaX = (upperLimit - lowLimit) / intervalCount;
        double sumOdd = 0;
        double sumEven = 0;

        for (int i = 1; i < intervalCount; i++)
        {
            if (i.IsEven()) sumEven += fx(lowLimit + deltaX * i);
            else sumOdd += fx(lowLimit + deltaX * i);
        }

        sumOdd = 4 * sumOdd;
        sumEven = 2 * sumEven;

        double yTotal = fx(lowLimit) + fx(upperLimit) + sumOdd + sumEven;

        return yTotal * deltaX / 3;
    }
}