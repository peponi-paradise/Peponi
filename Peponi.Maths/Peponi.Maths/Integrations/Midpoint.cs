using Peponi.Maths.Extensions;

namespace Peponi.Maths.Integration;

/// <summary>
/// Compute by Midpoint rule.
/// <br/>
/// <see href="주소 넣어야 함"/>
/// </summary>
public static class Midpoint
{
    /// <summary>
    /// <code>
    /// Compute by given params
    /// Converted values to double internally
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

        double result = 0;

        for (int i = 1; i <= _Ys.Count - 1; i += 2)
        {
            result += _Ys[i] * (_Xs[i + 1] - _Xs[i - 1]);
        }

        return result;
    }

    public static double Integrate(Func<double, double> fx, double lowLimit, double upperLimit, int intervalCount)
    {
        if (lowLimit > upperLimit) throw new ArgumentException($"Low limit ({lowLimit}) could not bigger than upper limit ({upperLimit})");
        else if (fx == null) throw new ArgumentNullException("fx is null");

        double deltaX = (upperLimit - lowLimit) / intervalCount;
        double sum = 0;

        for (int i = 0; i < intervalCount; i++)
        {
            sum += fx((2 * lowLimit + (2 * i + 1) * deltaX) / 2);
        }

        return sum * deltaX;
    }
}