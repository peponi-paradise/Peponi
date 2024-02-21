using Peponi.Maths.Extensions;

namespace Peponi.Maths.Integration;

/// <summary>
/// Compute by Simpson's 3/8 rule.
/// </summary>
/// <remarks>
/// <see href="https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.Maths/Peponi.Maths/Docs/README.md"/>
/// </remarks>
public static class Simpson3over8
{
    /// <summary>
    /// <code>
    /// Compute by given params
    /// Convert values to double internally
    /// Count of xs and ys are should be equal
    /// ' Data length - 1 ' must be multiple of 3
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
        else if ((xs.Count - 1) % 3 != 0) throw new ArgumentException("\"Array length - 1\" must be multiple of 3");
        else
        {
            _Xs = xs.Select(x => Convert.ToDouble(x)).ToList();
            _Ys = ys.Select(x => Convert.ToDouble(x)).ToList();
            if (!_Xs.IsIntervalUniform()) throw new ArgumentException("X axis array's interval should be uniform");
        }

        double intervalH = (_Xs.Max() - _Xs.Min()) / (_Xs.Count - 1) * 3 / 8;

        double yTotal = 0;
        for (int i = 0; i < _Ys.Count - 2; i += 3)
        {
            yTotal += _Ys[i] + 3 * _Ys[i + 1] + 3 * _Ys[i + 2] + _Ys[i + 3];
        }

        double result = intervalH * yTotal;

        return result;
    }

    /// <summary>
    /// Compute by given function
    /// </summary>
    /// <param name="fx"></param>
    /// <param name="lowLimit">Low limit &lt; Upper limit</param>
    /// <param name="upperLimit">Low limit &lt; Upper limit</param>
    /// <param name="intervalCount">Must be multiple of 3</param>
    /// <returns>Computed value</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public static double Integrate(Func<double, double> fx, double lowLimit, double upperLimit, int intervalCount)
    {
        if (lowLimit > upperLimit) throw new ArgumentException($"Low limit ({lowLimit}) could not bigger than upper limit ({upperLimit})");
        else if (fx == null) throw new ArgumentNullException("fx is null");
        else if (intervalCount % 3 != 0) throw new ArgumentException("Interval count must be multiple of 3");

        double deltaX = (upperLimit - lowLimit) / intervalCount;
        double yTotal = 0;

        for (int i = 0; i < intervalCount - 2; i += 3)
        {
            yTotal += fx(lowLimit + deltaX * i) + 3 * fx(lowLimit + deltaX * (i + 1)) + 3 * fx(lowLimit + deltaX * (i + 2)) + fx(lowLimit + deltaX * (i + 3));
        }

        return yTotal * deltaX * 3 / 8;
    }
}