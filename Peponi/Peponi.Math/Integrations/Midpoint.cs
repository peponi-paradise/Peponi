namespace Peponi.Math.Integration;

public static class Midpoint
{
    /// <summary>
    /// 중점공식은 바 그래프 형태에서 가장 정확성 높음
    /// </summary>
    public static double Integrate(List<double> xs, List<double> ys)
    {
        double result = 0;

        for (int i = 0; i < ys.Count; i++)
        {
            // 0 이하 값 일괄 0으로 처리
            ys[i] = ys[i] > 0 ? ys[i] : 0;
        }

        //  끝점 제외한 나머지 계산
        for (int i = 0; i < xs.Count - 1; i++)
        {
            double YMidpoint = 0;

            if (ys[i] < ys[i + 1])
            {
                YMidpoint = ys[i] + (System.Math.Abs(ys[i + 1] - ys[i])) / 2;
            }
            else
            {
                YMidpoint = ys[i + 1] + (System.Math.Abs(ys[i + 1] - ys[i])) / 2;
            }

            result += YMidpoint * (float)System.Math.Abs(xs[i + 1] - xs[i]);
        }

        return result;
    }
}