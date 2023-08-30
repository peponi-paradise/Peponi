using Peponi.Math.Calculation;

namespace Peponi.Math.Integration;

public static class Simpson1over3
{
    /// <summary>
    /// 심슨 1/3오더는 곡선구간이고 각 구간이 짧을 수록 정확, 반드시 구간의 수가 짝수여야 함
    /// </summary>
    public static double Integrate(List<double> xs, List<double> ys)
    {
        if (xs.Count.IsEven() || ys.Count.IsEven()) return -999;      //포인트가 홀수여야 구간 수가 짝수가 나옴

        double result = 0;
        double sumOdd = 0;
        double sumEven = 0;
        double intervalDivThree = (double)(System.Math.Abs(xs.Max() - xs.Min()) / (xs.Count - 1) / 3);

        for (int i = 0; i < ys.Count; i++) ys[i] = ys[i] > 0 ? ys[i] : 0;   // 음수 0으로 처리

        for (int i = 1; i < ys.Count - 1; i++)
        {
            if (i.IsEven()) sumEven += ys[i];
            else sumOdd += ys[i];
        }

        sumOdd = 4 * sumOdd;
        sumEven = 2 * sumEven;

        double YTotal = ys[0] + ys[ys.Count - 1] + sumOdd + sumEven;

        result = intervalDivThree * YTotal;
        return result;
    }
}