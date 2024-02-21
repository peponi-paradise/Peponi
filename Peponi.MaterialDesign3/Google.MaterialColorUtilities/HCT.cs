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

namespace Google.MaterialColorUtilities;

/// <summary>
/// Redefine for getting tonal spot
/// </summary>
internal static class HCT
{
    public static (double Hue, double Chroma) FromColor(Color color) => CAM16.FromColor(color);

    public static Color ToColor(double hue, double chroma, double tone) => HCTSolver.SolveToColor(hue, chroma, tone);
}