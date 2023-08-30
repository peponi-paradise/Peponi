using Peponi.Math.Calculation;

namespace Peponi.Math.Integration;

public static class Simpson3over8
{
    /// <summary>
    /// 심슨 3/8은 잘 쓰이지 않음. 제약 조건은 1/3 룰과 동일
    /// </summary>
    public static double Integrate(List<double> xs, List<double> ys)
    {
        if (xs.Count.IsOdd() || ys.Count.IsOdd()) return -999;

        double result = 0;
        double sumTriple = 0;
        double sumDouble = 0;
        double intervalH = (xs.Max() - xs.Min()).Abs() / (xs.Count - 1) * 3 / 8;

        for (int i = 0; i < ys.Count; i++) ys[i] = ys[i] > 0 ? ys[i] : 0;   // 음수 0으로 처리

        for (int i = 1; i < ys.Count - 2; i += 3)
        {
            sumTriple += ys[i] + ys[i + 1];
            sumDouble += ys[i + 2];
        }

        sumTriple *= 3;
        sumDouble *= 2;

        double yTotal = ys[0] + ys[ys.Count - 1] + sumTriple + sumDouble;
        result = intervalH * yTotal;

        return result;
    }
}