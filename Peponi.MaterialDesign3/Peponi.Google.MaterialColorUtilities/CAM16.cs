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

using System.Drawing;

namespace Peponi.Google.MaterialColorUtilities;

internal static class CAM16
{
    /// <summary>
    /// <para>
    /// Original name : fromIntInViewingConditions(int argb, ViewingConditions viewingConditions)
    /// </para>
    /// <para>
    /// Create a CAM16 color from a color in defined viewing conditions.
    /// </para>
    /// </summary>
    /// <param name="color">argb ARGB representation of a color</param>
    /// <returns>The RGB => XYZ conversion matrix elements are derived scientific constants. While the values may differ at runtime due to floating point imprecision, keeping the values the same, and accurate, across implementations takes precedence</returns>
    public static (double Hue, double Chroma) FromColor(Color color)
    {
        // Transform ARGB color to XYZ
        double redL = color.R.Linearized();
        double greenL = color.G.Linearized();
        double blueL = color.B.Linearized();

        double x = 0.41233895 * redL + 0.35762064 * greenL + 0.18051042 * blueL;
        double y = 0.2126 * redL + 0.7152 * greenL + 0.0722 * blueL;
        double z = 0.01932141 * redL + 0.11916382 * greenL + 0.95034478 * blueL;

        return FromXyz(x, y, z);
    }

    /// <summary>
    /// <para>
    /// Original name : fromXyzInViewingConditions(double x, double y, double z, ViewingConditions viewingConditions)
    /// </para>
    /// <para>
    /// Using default viewing conditions
    /// </para>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    private static (double Hue, double Chroma) FromXyz(double x, double y, double z)
    {
        // Transform XYZ to 'cone'/'rgb' responses
        var rgb = MathUtils.MatrixMultiply(new double[] { x, y, z }, HCTConstants.XYZ_TO_CAM16RGB);

        // Discount illuminant
        double rD = 1.0211777027575202 * rgb[0];
        double gD = 0.9863077294280123 * rgb[1];
        double bD = 0.9339605082802299 * rgb[2];

        // Chromatic adaptation
        double rAF = Math.Pow(0.003884814537800353 * Math.Abs(rD), 0.42);
        double gAF = Math.Pow(0.003884814537800353 * Math.Abs(gD), 0.42);
        double bAF = Math.Pow(0.003884814537800353 * Math.Abs(bD), 0.42);
        double rA = Math.Sign(rD) * 400.0 * rAF / (rAF + 27.13);
        double gA = Math.Sign(gD) * 400.0 * gAF / (gAF + 27.13);
        double bA = Math.Sign(bD) * 400.0 * bAF / (bAF + 27.13);

        // redness-greenness
        double a = (11.0 * rA + -12.0 * gA + bA) / 11.0;
        // yellowness-blueness
        double b = (rA + gA - 2.0 * bA) / 9.0;

        // hue
        double atanDegrees = Math.Atan2(b, a) * 57.29577951308232;
        double hue = atanDegrees < 0 ? atanDegrees + 360.0 : atanDegrees >= 360 ? atanDegrees - 360.0 : atanDegrees;

        // CAM16 chroma, colorfulness, and saturation.
        double ac = (40.0 * rA + 20.0 * gA + bA) * 0.050845959022293774;
        double j = 100.0 * Math.Pow(ac / 29.980997194447333, 1.3173270022537198);
        double huePrime = (hue < 20.14) ? hue + 360 : hue;
        double eHue = 0.25 * (Math.Cos(Math.PI / 180 * huePrime + 2.0) + 3.8);
        double p1 = 3911.227617099523 * eHue;
        double u = (20.0 * rA + 20.0 * gA + 21.0 * bA) / 20.0;
        double t = p1 * Math.Sqrt(a * a + b * b) / (u + 0.305);
        double alpha = Math.Pow(1.64 - Math.Pow(0.29, 0.18418651851244416), 0.73) * Math.Pow(t, 0.9);
        double chroma = alpha * Math.Sqrt(j / 100.0);

        return (hue, chroma);
    }
}