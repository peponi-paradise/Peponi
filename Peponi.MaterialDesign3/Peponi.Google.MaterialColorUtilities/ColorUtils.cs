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

internal static class ColorUtils
{
    /// <summary>
    /// <para>
    /// Original name : argbFromRgb(int red, int green, int blue)
    /// </para>
    /// <para>
    /// Converts a color from RGB components to ARGB format.
    /// </para>
    /// </summary>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    /// <returns></returns>
    public static int ARGBFromRGB(int red, int green, int blue)
    {
        return (255 << 24) | ((red & 255) << 16) | ((green & 255) << 8) | (blue & 255);
    }

    /// <summary>
    /// <para>
    /// Original name : argbFromLstar(double lstar)
    /// </para>
    /// <para>
    /// Converts an L* value to an ARGB representation.
    /// </para>
    /// </summary>
    /// <param name="tone">L* in L*a*b*</param>
    /// <returns>ARGB representation of grayscale color with lightness matching L*</returns>
    public static int ARGBFromTone(double tone)
    {
        int component = yFromTone(tone).Delinearized();
        return ARGBFromRGB(component, component, component);
    }

    /// <summary>
    /// <para>
    /// Original name : yFromLstar(double lstar)
    /// </para>
    /// <para>
    /// Converts an L* value to a Y value.<br/>
    /// L* in L* a*b* and Y in XYZ measure the same quantity, luminance.<br/>
    /// L* measures perceptual luminance, a linear scale.Y in XYZ measures relative luminance, alogarithmic scale.
    /// </para>
    /// <para>
    /// </para>
    /// </summary>
    /// <param name="tone">L* in L*a*b*</param>
    /// <returns>in XYZ</returns>
    public static double yFromTone(double tone)
    {
        return 100.0 * labInvf((tone + 16.0) / 116.0);

        double labInvf(double ft)
        {
            double e = 0.0088564516790356;
            double kappa = 903.2962962962963;
            double ft3 = ft * ft * ft;
            if (ft3 > e)
            {
                return ft3;
            }
            else
            {
                return (116 * ft - 16) / kappa;
            }
        }
    }

    /// <summary>
    /// <para>
    /// Original name : linearized(int rgbComponent)
    /// </para>
    /// <para>
    /// Linearizes an RGB component.
    /// </para>
    /// </summary>
    /// <param name="channel">0 <= rgb_component <= 255, represents R/G/B channel</param>
    /// <returns>0.0 <= output <= 100.0, color channel converted to linear RGB space</returns>
    public static double Linearized(this byte channel)
    {
        double normalized = channel / 255.0;
        if (normalized <= 0.040449936) return normalized * 7.739938080495356;
        else return Math.Pow((normalized + 0.055) / 1.055, 2.4) * 100.0;
    }

    /// <summary>
    /// <para>
    /// Original name : delinearized(double rgbComponent)
    /// </para>
    /// <para>
    /// Delinearizes an RGB component.
    /// </para>
    /// </summary>
    /// <param name="rgbComponent">0.0 <= rgb_component <= 100.0, represents linear R/G/B channel</param>
    /// <returns>0 <= output <= 255, color channel converted to regular RGB space</returns>
    public static int Delinearized(this double rgbComponent)
    {
        double normalized = rgbComponent / 100.0;
        double delinearized = normalized <= 0.0031308 ? normalized * 12.92 : 1.055 * Math.Pow(normalized, 1.0 / 2.4) - 0.055;

        return MathUtils.ClampInt(0, 255, (int)Math.Round(delinearized * 255.0));
    }
}