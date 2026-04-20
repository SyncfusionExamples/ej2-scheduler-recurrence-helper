# ej2-scheduler-recurrence-helper
A server-side C# recurrence parser that generates collections of event occurrence dates from a provided recurrence rule. This helper is intended for integration with scheduling backends.

Repository Description:
A lightweight C# helper to parse recurrence rules and compute occurrence dates for server-side scheduling, suitable for calendar and scheduler systems.

Project Overview
This project provides a focused server-side helper (single-file C#) that parses recurrence rules and returns date collections representing event occurrences. It is intended for easy integration into .NET scheduling workflows and backend services.

Features
- Parses common recurrence rules and computes occurrence lists
- Produces date collections for scheduled events
- Simple to add into existing .NET projects

Prerequisites
- .NET SDK (6.0+ or compatible runtime)
- Basic C# knowledge

Installation
1. Add `RecurrenceHelper.cs` to your project.
2. Build with your normal .NET build process (for example, `dotnet build`).

Usage
Conceptual example:
```csharp
var helper = new RecurrenceHelper();
var dates = helper.GenerateOccurrences(startDate, recurrenceRule);
```
