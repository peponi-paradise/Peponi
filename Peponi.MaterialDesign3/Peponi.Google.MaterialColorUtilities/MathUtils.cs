/*
 * Copyright 2021 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

namespace Peponi.Google.MaterialColorUtilities;

internal static class MathUtils
{
    /// <summary>
    /// <para>
    /// Original name : clampInt(int min, int max, int input)
    /// </para>
    /// <para>
    /// Clamps an integer between two integers.
    /// </para>
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="input"></param>
    /// <returns>input when min &lt;= input &lt;= max, and either min or max otherwise.</returns>
    public static int ClampInt(int min, int max, int input)
    {
        if (input < min)
        {
            return min;
        }
        else if (input > max)
        {
            return max;
        }

        return input;
    }

    /// <summary>
    /// <para>
    /// Original name : matrixMultiply(double[] row, double[][] matrix)
    /// </para>
    /// <para>
    /// Multiplies a 1x3 row vector with a 3x3 matrix.
    /// </para>
    /// </summary>
    /// <param name="row"></param>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public static double[] MatrixMultiply(double[] row, double[][] matrix)
    {
        double a = row[0] * matrix[0][0] + row[1] * matrix[0][1] + row[2] * matrix[0][2];
        double b = row[0] * matrix[1][0] + row[1] * matrix[1][1] + row[2] * matrix[1][2];
        double c = row[0] * matrix[2][0] + row[1] * matrix[2][1] + row[2] * matrix[2][2];
        return new double[] { a, b, c };
    }
}