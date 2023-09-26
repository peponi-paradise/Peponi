namespace Peponi.Math.Integration;

public static class Trapezoidal
{
    /// <summary>
    /// 사다리꼴은 이산값 직선으로 이을수록 정확성 올라감
    /// </summary>
    public static double Integrate(List<double> xs, List<double> ys)
    {
        if (xs.Count != ys.Count) throw new ArgumentException($"Input value count mismatched. xs : {xs.Count}, ys : {ys.Count}");
        else if (xs.Count < 2) throw new ArgumentException("Required at least 2 points");

        double result = 0;

        for (int i = 0; i < xs.Count - 1; i++)
        {
            result += (xs[i + 1] - xs[i]) * (ys[i + 1] + ys[i]) / 2;
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
            sum += fx(lowLimit + deltaX * i) + fx(lowLimit + deltaX * (i + 1));
        }

        return sum * deltaX / 2;
    }
}