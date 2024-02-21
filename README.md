# Peponi Library


- [Peponi Library](#peponi-library)
  - [1. Instruction](#1-instruction)
    - [1.1. About](#11-about)
    - [1.2. License](#12-license)
  - [2. Contents](#2-contents)
    - [2.1. Peponi.Core](#21-peponicore)
    - [2.2. Peponi.FreeSpaceManagement](#22-peponifreespacemanagement)
    - [2.3. Peponi.Logger](#23-peponilogger)
    - [2.4. Peponi.Maths](#24-peponimaths)
    - [2.5. Peponi.SourceGenerators](#25-peponisourcegenerators)
    - [2.6. Peponi.MaterialDesign3.WPF](#26-peponimaterialdesign3wpf)
    - [2.7. Peponi.Google.MaterialColorUtilities](#27-peponigooglematerialcolorutilities)


## 1. Instruction


- This library is under MIT License.
- GitHub : [Peponi](https://github.com/peponi-paradise/Peponi)
- Blog : [Peponi](https://peponi-paradise.tistory.com)
- Instruction & API information is on following section


### 1.1. About


```text
This is C# library made by Peponi.
Key purposes are:

    1. Act as 3rd party library for not supported from major libraries
    2. Common API use for development
    3. Better Maintenancability
```


### 1.2. License


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


## 2. Contents


### 2.1. Peponi.Core


```text
Peponi.Core is a package for common usage of peponi library.
Included contents are:

1. Design pattern
   - Singleton
2. Utility
   - Helpers
      + Directory
      + Member
      + Process
      + Registry
      + Storage  
   - Minidump
```

- Install : `NuGet\Install-Package Peponi.Core`
- Git : [Peponi.Core](https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.Core)


### 2.2. Peponi.FreeSpaceManagement


```text
Peponi.FreeSpaceManagement is a package for maintaining free space of storage.
Base concepts are:

1. Remove oldest file
    - Automatically remove oldest file when free space is under setted disk preserve percent value
```

- Install : `NuGet\Install-Package Peponi.FreeSpaceManagement`
- Git : [Peponi.FreeSpaceManagement](https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.FreeSpaceManagement)


### 2.3. Peponi.Logger


```text
Peponi.Logger is a package for logging.
Base concepts are:

1. Fast return
   - Add log item and return immediately
2. High performance logger
   - Has processor & writer per each logger
```

- Install : `NuGet\Install-Package Peponi.Logger`
- Git : [Peponi.Logger](https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.Logger)


### 2.4. Peponi.Maths


```text
Peponi.Maths is a package for Mathematics.
Including contents are:

1. Coordinates
    - Cartesian (2D & 3D)
    - Cylindrical
    - Polar
    - Spherical
2. Numerical integrations
    - Trapezoidal
    - Midpoint
    - Simpson's rule (1/3 & 3/8)
3. Moving Averages
    - Simple moving average
4. Unit conversion
    - Angle
    - Angular speed
    - Area
    - Dry volume
    - Energy
    - Force
    - Length
    - Prefix
    - Pressure
    - Speed
    - Temperature
    - Volume
    - Weight
5. Windowing
    - Tumbling
    - Sliding
    - Hopping
```

- Install : `NuGet\Install-Package Peponi.Maths`
- Git : [Peponi.Maths](https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.Maths)


### 2.5. Peponi.SourceGenerators


```text
Peponi.SourceGenerators is a package for generating codes.
Including generators are:

1. ICommand
2. Object injection
3. Method caller in property
4. INotifyPropertyChanged
5. Property
6. Raise can execute
7. Raise property changed
8. gRPC Client
9. gRPC Server
```

- Install : `NuGet\Install-Package Peponi.SourceGenerators`
- Git : [Peponi.SourceGenerators](https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.SourceGenerators)


### 2.6. Peponi.MaterialDesign3.WPF


```text
Peponi.MaterialDesign3.WPF is a package for implementing Material design 3 of google.
Contents are:

1. Colors
	- Getting colors using DynamicResource, StaticResource
2. Fonts
	- Getting Font family, size, weight, line height using DynamicResource, StaticResource
```

- Install : `Nuget\Install-Package Peponi.MaterialDesign3.WPF`
- Git : [Peponi.MaterialDesign3.WPF](https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.MaterialDesign3/Peponi.MaterialDesign3.WPF)


### 2.7. Peponi.Google.MaterialColorUtilities


```text
Peponi.Google.MaterialColorUtilities is a package for implementing Material design 3 color of google.

This project is originated from material-color-utilities (https://github.com/material-foundation/material-color-utilities)

Most parts of original library are removed except getting tonal spot.
```

- Install : `Nuget\Install-Package Peponi.Google.MaterialColorUtilities`
- Git : [Peponi.Google.MaterialColorUtilities](https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.MaterialDesign3/Peponi.Google.MaterialColorUtilities)