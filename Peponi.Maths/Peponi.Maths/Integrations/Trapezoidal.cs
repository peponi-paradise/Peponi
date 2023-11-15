namespace Peponi.Maths.Integration;

/// <summary>
/// Compute by Trapezoidal rule.
/// <br/>
/// <see href="주소 넣어야 함"/>
/// </summary>
public static class Trapezoidal
{
    /// <summary>
    /// <code>
    /// Compute by given params
    /// Convert values to double internally
    /// Count of xs and ys are should be equal
    /// </code>
    /// </summary>
    /// <typeparam name="X">Struct type</typeparam>
    /// <typeparam name="Y">Struct type</typeparam>
    /// <param name="xs">At least 2 points</param>
    /// <param name="ys"></param>
    /// <returns>Computed value</returns>
    /// <exception cref="ArgumentException"></exception>
    public static double Integrate<X, Y>(List<X> xs, List<Y> ys) where X : struct
                                                                            where Y : struct
    {
        if (xs.Count != ys.Count) throw new ArgumentException($"Input value count mismatched. xs : {xs.Count}, ys : {ys.Count}");
        else if (xs.Count < 2) throw new ArgumentException("Required at least 2 points");

        List<double> _Xs = xs.Select(x => Convert.ToDouble(x)).ToList();
        List<double> _Ys = ys.Select(x => Convert.ToDouble(x)).ToList();

        double result = 0;

        for (int i = 0; i < xs.Count - 1; i++)
        {
            result += (_Xs[i + 1] - _Xs[i]) * (_Ys[i + 1] + _Ys[i]) / 2;
        }

        return result;
    }

    /// <summary>
    /// Compute by given function
    /// </summary>
    /// <param name="fx"></param>
    /// <param name="lowLimit">Low limit &lt; Upper limit</param>
    /// <param name="upperLimit">Low limit &lt; Upper limit</param>
    /// <param name="intervalCount"></param>
    /// <returns>Computed value</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public static double Integrate(Func<double, double> fx, double lowLimit, double upperLimit, int intervalCount)
    {
        if (lowLimit > upperLimit) throw new ArgumentException($"Low limit ({lowLimit}) could not bigger than upper limit ({upperLimit})");
        else if (fx == null) throw new ArgumentNullException("fx is null");

        double deltaX = (upperLimit - lowLimit) / intervalCount;
        double sum = 0;

        for (int i = 0; i < intervalCount; i++)
        {
            sum += fx(lowLimit + deltaX * i) + fx(lowLimit + deltaX * (i + 1));
        }

        return sum * deltaX / 2;
    }
}