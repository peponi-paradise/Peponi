# Peponi.MaterialDesign3.WPF


- [Peponi.MaterialDesign3.WPF](#peponimaterialdesign3wpf)
  - [1. Instruction](#1-instruction)
    - [1.1. About Peponi.MaterialDesign3.WPF](#11-about-peponimaterialdesign3wpf)
      - [1.1.1. Peponi.MaterialDesign3.WPF license](#111-peponimaterialdesign3wpf-license)
      - [1.1.2. Peponi.MaterialDesign3.WPF install](#112-peponimaterialdesign3wpf-install)
  - [2. Peponi.MaterialDesign3.WPF](#2-peponimaterialdesign3wpf)
    - [2.1. Quick start](#21-quick-start)
    - [2.2. MaterialTheme](#22-materialtheme)
    - [2.2.1. MaterialTheme Members](#221-materialtheme-members)


## 1. Instruction


- This package is under MIT License.
- GitHub : [Peponi](https://github.com/peponi-paradise/Peponi)
- Blog : [Peponi](https://peponi-paradise.tistory.com)
- Instruction & API information is on following section


### 1.1. About Peponi.MaterialDesign3.WPF


```text
Peponi.MaterialDesign3.WPF is a package for implementing Material design 3 of google.
Contents are:

1. Colors
   - Getting colors using DynamicResource
2. Fonts
   - Getting Font family, size, weight, line height using DynamicResource
```


#### 1.1.1. Peponi.MaterialDesign3.WPF license


```text
The MIT License (MIT)

Copyright (c) 2024 peponi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```


#### 1.1.2. Peponi.MaterialDesign3.WPF install


```text
Nuget\Install-Package Peponi.MaterialDesign3.WPF
```


## 2. Peponi.MaterialDesign3.WPF


### 2.1. Quick start


- Import resources to App.xaml
    ```xml
      <Application
        x:Class="Peponi.MaterialDesign3.WPF.Tests.App"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:theme="https://github.com/peponi-paradise/Peponi/MaterialDesign3">
        <Application.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <!-- Contains default resource keys (Optional) -->
                    <!-- If user use this resource, import it first -->
                    <ResourceDictionary Source="/Peponi.MaterialDesign3.WPF;component/MaterialTheme.xaml" />
                    <!-- Theme provider -->
                    <theme:MaterialTheme />
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
        </Application.Resources>
      </Application>
    ```
- Configure options of theme
    ```xml
      <!-- Xaml -->

      <theme:MaterialTheme
        Primary="Magenta"
        Secondary="#FF3658C3"
        Tertiary="MediumSeaGreen"
        ColorMode="Auto"
        UseWindowsAccentColor="True"

        FontFamily="{StaticResource RobotoFlex}"
        SecondaryFontFamily="{StaticResource RobotoSerif}"
        TertiaryFontFamily="Arial" />
    ```
    ```cs
        // Code

        MaterialTheme.Current.Primary = Colors.Magenta;
        MaterialTheme.Current.Secondary = Color.FromArgb(0xFF, 0x36, 0x58, 0xC3);
        MaterialTheme.Current.Tertiary = Colors.MediumSeaGreen;
        MaterialTheme.Current.ColorMode = ColorMode.Auto;
        MaterialTheme.Current.UseWindowsAccentColor = true;

        MaterialTheme.Current.FontFamily = FontHelper.GetFontFamily("RobotoFlex");
        MaterialTheme.Current.SecondaryFontFamily = FontHelper.GetFontFamily("RobotoSerif");
        MaterialTheme.Current.FontFamily = FontHelper.GetFontFamily("Microsoft Sans Serif");
    ```
- User could set properties via property window of designer
    ![designerProperty](DesignerProperty.PNG)


### 2.2. MaterialTheme


- `MaterialTheme` provides color & font set of [Material Design 3](https://m3.material.io/) of google.
- Provided colors are tonal palette as default.
- Three default fonts provided.
    - [Roboto Flex](https://fonts.google.com/specimen/Roboto+Flex)
    - [Roboto Serif](https://fonts.google.com/specimen/Roboto+Serif)
    - [Pretendard](https://fonts.adobe.com/fonts/pretendard)
    - Default font family (See [MaterialTheme Members](#221-materialtheme-members))
        - FontFamily : Roboto Flex
        - SecondaryFontFamily : Roboto Serif
        - TertiaryFontFamily : Pretendard
- Default tonal palette is same as following image
    - Default key color : #757575
    ![defaultTonalPalette](DefaultTonalPalette.PNG)


### 2.2.1. MaterialTheme Members


1. Members
    |Type|Name|Description|
    |-------|-------|-------|
    |Color|Primary|Primary color of palette<br>This value could not be `null`|
    |Color?|Secondary|Secondary color of palette|
    |Color?|Tertiary|Tertiary color of palette|
    |ColorMode|ColorMode|Set color mode for default color set|
    |bool|UseWindowsAccentColor|Use windows accent color option<br>Supports Windows 10, 11|
    |Dictionary<TonalPalettes, TonalPalette>|ColorPalettes|Current color palettes|
    |FontFamily?|FontFamily|Primary font family|
    |FontFamily?|SecondaryFontFamily|Secondary font family|
    |FontFamily?|TertiaryFontFamily|Tertiary font family|
    |MaterialTheme|Current|Current theme|
2. Methods
    |Return type|Name|Description|
    |-------|-------|-------|
    |void|SetPalettes(Color)|Create tonal spot palette by given color<br>Neutral, Neutral variant colors are decided by primary color|
    |void|SetPalettes(Color, Color?, Color?)|Create tonal spot palette by given color<br>Neutral, Neutral variant colors are decided by primary color|
    |bool|LoadXaml(string)|Sets color, font values by given xaml|
    |bool|SetCollection(Dictionary<string, object>)|Sets color, font values by given dictionary|
