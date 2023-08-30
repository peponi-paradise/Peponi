namespace Peponi.Math.Integration;

public static class Trapezoidal
{
    /// <summary>
    /// 사다리꼴은 이산값 직선으로 이을수록 정확성 올라감
    /// </summary>
    public static double Integrate(List<double> xs, List<double> ys)
    {
        double result = 0;

        for (int i = 0; i < ys.Count; i++)
        {
            // 0 이하 값 일괄 0으로 처리
            ys[i] = ys[i] > 0 ? ys[i] : 0;
        }

        // 끝점 제외한 나머지 계산
        for (int i = 0; i < xs.Count - 1; i++)
        {
            result += System.Math.Abs(xs[i + 1] - xs[i]) * System.Math.Abs(ys[i + 1] + ys[i]) / 2;
        }

        return result;
    }
}