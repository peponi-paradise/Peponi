using Peponi.Math.Extensions;

namespace Peponi.Math.Integration;

public static class Simpson1over3
{
    /// <summary>
    /// 심슨 1/3오더는 곡선구간이고 각 구간이 짧을 수록 정확, 반드시 구간의 수가 짝수여야 함 <br/>
    /// 각 구간의 길이는 일정해야 함
    /// </summary>
    public static double Integrate(List<double> xs, List<double> ys)
    {
        if (xs.Count != ys.Count) throw new ArgumentException($"Input value count mismatched. xs : {xs.Count}, ys : {ys.Count}");
        //포인트가 홀수여야 구간 수가 짝수가 나옴
        else if (xs.Count < 3) throw new ArgumentException("Required at least 3 points");
        else if (!xs.Count.IsOdd()) throw new ArgumentException("Input array's count should be odd");
        else if (!xs.IsIntervalUniform()) throw new ArgumentException("X axis array's interval should be uniform");

        double sumOdd = 0;
        double sumEven = 0;
        double intervalH = (xs.Max() - xs.Min()) / (xs.Count - 1) / 3;

        for (int i = 1; i < ys.Count - 1; i++)
        {
            if (i.IsEven()) sumEven += ys[i];
            else sumOdd += ys[i];
        }

        sumOdd = 4 * sumOdd;
        sumEven = 2 * sumEven;

        double yTotal = ys[0] + ys[ys.Count - 1] + sumOdd + sumEven;
        double result = intervalH * yTotal;

        return result;
    }
}