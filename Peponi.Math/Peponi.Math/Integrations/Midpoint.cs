using Peponi.Math.Extensions;

namespace Peponi.Math.Integration;

public static class Midpoint
{
    /// <summary>
    /// 중점공식은 바 그래프 형태에서 가장 정확성 높음
    /// </summary>
    public static double Integrate<T, V>(List<T> xs, List<V> ys) where T : struct
                                                                            where V : struct
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