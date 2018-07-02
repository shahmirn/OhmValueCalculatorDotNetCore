# Ohm Value Calculator - .NET Core Backend - Showcase Project

Project Requirements
- The electronic color code (http://en.wikipedia.org/wiki/Electronic_color_code) is used to indicate the values or ratings of electronic components, very commonly for resistors.
Write a class that implements an IOhmValueCalculator interface.
```C#
public interface IOhmValueCalculator
{
   /// <summary>
   /// Calculates the Ohm value of a resistor based on the band colors.
   /// </summary>
   /// <param name="bandAColor">The color of the first figure of component value band.</param>
   /// <param name="bandBColor">The color of the second significant figure band.</param>
   /// <param name="bandCColor">The color of the decimal multiplier band.</param>
   /// <param name="bandDColor">The color of the tolerance value band.</param>
   int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
}
```

- Write the unit tests you feel are necessary to adequately test the code.

## Working Demo
- http://ohmvaluecalculator.azurewebsites.net/api/calculator/bandAColor/red/bandBColor/violet/bandCColor/green/bandDColor/brown

## Version
0.0.1

## Tech
* [Visual Studio 2017] - Fully-featured integrated development environment (IDE) for Android, iOS, Windows, web, and cloud.
* [.NET Core] - A developer platform for building all your apps.
* [NUnit] - NUnit is a unit-testing framework for all .Net languages.
* [Fluent Assertions] - A very extensive set of extension methods that allow you to more naturally specify the expected outcome of a TDD or BDD-style unit tests.

## Running Locally
- git clone https://github.com/shahmirn/OhmValueCalculatorDotNetCore.git
- Either install Visual Studio 2017 with the "ASP.NET and Web Development" workload, or install .NET Core 2.1 SDK
- If using Visual Studio
  - open OhmValueCalculator.sln
  - Go to Debug, then Start Debugging
  
- If using the command line / .NET Core 2.1 SDK
  - cd OhmValueCalculatorDotNetCore
  - dotnet restore
  - dotnet run --project OhmValueCalculator

- Go to http://localhost:56111/api/calculator/bandAColor/red/bandBColor/violet/bandCColor/green/bandDColor/brown
- To see results for other colors, replace the band colors in the URL with other valid colors. Refer to http://en.wikipedia.org/wiki/Electronic_color_code to see other valid color combinations.
  
## Running tests
- If using Visual Studio
  - Go to Build, then Build Solution
  - Go to Test, Windows, then Test Explorer
  - Click on Run All
- If using command line / .NET Core 2.1 SDK
  - cd OhmValueCalculatorDotNetCore
  - dotnet restore
  - dotnet test OhmValueCalculator.Tests -v n
  
## Interface Deviations
The original problem specified an interface that returns an int.

However, given that band D is the tolerance band, the user would be interested in the resistance of the resistor based 
on the first three bands, plus the deviation / variance based on the fourth band.

This necessitates returning an object instead, which contains a Resistance, Minimum, and Maximum value.

## Corresponding front-end repository
- https://github.com/shahmirn/ohm-value-calculator-react

## Todo's
- Add additional code comments
- Create an enum for the colors for the different bands instead of allowing any arbitrary string
- Use [Swashbuckle.AspNetCore] to add swagger documentation

[Visual Studio 2017]:https://visualstudio.microsoft.com/vs/
[.NET Core]:https://www.microsoft.com/net/
[NUnit]:http://nunit.org/
[Fluent Assertions]:https://fluentassertions.com/
[Swashbuckle.AspNetCore]:https://github.com/domaindrivendev/Swashbuckle.AspNetCore
