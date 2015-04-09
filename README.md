### Product description
* Visual Studio project template for creating Units of Measurement C# class library.
* Units of measurement generated from design-time T4 text template according to simple definitions in a text file (data model).
 
    > You specify (in the text file) what units are required, their naming, underlying value type (_float_, _double_ or _decimal_) as well as conversion and arithmetic (operator) relationships between units. Text template generating units can be modified so the functionality of target library can be easily fit to your needs.

* Units of measurement generated as types (_partial structs_).

    > Thus, dimensional analysis can be performed as a syntax check at compile time (dimensional issues displayed in Visual Studio as syntax errors). See [this](https://github.com/mangh/unitsofmeasurement/wiki/Detecting-dimensional-issues-(example)) example.
    
* Units of measurement for any of the fundamental dimensions: _Length_, _Time_, _Mass_, _Temperature_, _ElectricCurrent_, _AmountOfSubstance_, _LuminousIntensity_ as well as _Other_ (e.g. _Money_ for currency units) and any of their combinations.
* Arithmetic (+, ++, -, --, *, /) and comparison (==, !=, <, <=, >, >=) operators to perform calculations directly on quantities of unit type. See [this](https://github.com/mangh/unitsofmeasurement/wiki/Detecting-dimensional-issues-(example)) example.
* Conversions of _quantities_ to/from other (but compatible) unit types.

Go to [Wiki](https://github.com/mangh/unitsofmeasurement/wiki) pages for more information.

### How to use it?
Assuming you have already installed `UnitsOfMeasurement.vsix` component (see [Releases](https://github.com/mangh/unitsofmeasurement/releases) page for download and installation instructions), follow this general process to create a library:

1. create a new project of type *"Units of Measurement C# Class Library"*, 
2. go to *Units* folder in Solution Explorer, 
3. edit `_definitions.txt` to specify units of measurement that you need for your solution, 
4. (*optional*) modify `_generator.tt` T4 text template to fit unit and/or scale template text to your needs, 
5. right-click on `_generator.tt`, select *"Run Custom Tool"* command (press OK on Security Warning). 
6. (*optional*) create some extension (.cs) files to extend generated unit/scale (partial) structs with additional properties, methods or operators, 
7. compile the project.
