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

public enum TonalPalettes
{
    Primary,
    Secondary,
    Tertiary,
    Neutral,
    NeutralVariant,
    Error
}

/// <summary>
/// Redefine for getting tonal spot
/// </summary>
public class TonalPalette
{
    public readonly double Hue;
    public readonly double Chroma;

    private readonly Dictionary<uint, Color> _cache = new();

    public TonalPalette()
    {
    }

    public TonalPalette(Color color)
    {
        var data = HCT.FromColor(color);
        Hue = data.Hue;
        // Chroma = data.Chroma > 48 ? 48 : data.Chroma;
        // Figma 플러그인에 맞게 Tonal spot으로 사용
        Chroma = 36;
    }

    public TonalPalette(double hue, double chroma)
    {
        Hue = hue;
        Chroma = chroma;
    }

    /// <summary>
    /// Creates an ARGB color with HCT hue and chroma of this TonalPalette instance, and the provided HCT tone.
    /// </summary>
    /// <param name="tone">HCT tone, measured from 0 to 100.</param>
    /// <returns>ARGB representation of a color with that tone.</returns>
    public Color this[uint tone]
    {
        get
        {
            if (!_cache.ContainsKey(tone))
            {
                _cache.Add(tone, HCT.ToColor(Hue, Chroma, tone));
            }
            return _cache[tone];
        }
    }
}