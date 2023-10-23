using Peponi.Math.Extensions;

namespace Peponi.Math.Integration;

public static class Simpson3over8
{
    /// <summary>
    /// 심슨 3/8은 잘 쓰이지 않음.
    /// </summary>
    public static double Integrate<T, V>(List<T> xs, List<V> ys) where T : struct
                                                                            where V : struct
    {
        List<double> _Xs;
        List<double> _Ys;
        if (xs.Count != ys.Count) throw new ArgumentException($"Input value count mismatched. xs : {xs.Count}, ys : {ys.Count}");
        else if ((xs.Count - 1) % 3 != 0) throw new ArgumentException("\"Array length - 1\" must be multiple of 3");
        else
        {
            _Xs = xs.Select(x => (double)Convert.ChangeType(x, typeof(double))).ToList();
            _Ys = ys.Select(x => (double)Convert.ChangeType(x, typeof(double))).ToList();
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