# MvvmAIO.Markup

XAML **markup extensions** for common CLR types (booleans, integers, `Guid`, `DateTime`, `TimeSpan`, `decimal`, `double`, `enum`, and more). The shared implementation ships in two NuGet packages: **WPF** and **Avalonia**.

## Packages

| Package | Description |
|--------|-------------|
| [`MvvmAIO.Markup.WPF`](https://www.nuget.org/packages/MvvmAIO.Markup.WPF) | WPF (`UseWPF`), multi-targeted from .NET Framework 4.6.1 through .NET 10 (Windows). |
| [`MvvmAIO.Markup.Avalonia`](https://www.nuget.org/packages/MvvmAIO.Markup.Avalonia) | Avalonia 12, .NET 8 / 10. |

Authors: **MvvmAIO**, **Skymly**, **wys0610**. License: **MIT**.

## Installation

```bash
dotnet add package MvvmAIO.Markup.WPF
# or
dotnet add package MvvmAIO.Markup.Avalonia
```

## Usage (WPF / Avalonia)

The library maps `MvvmAIO.Markup` into the default XAML namespace via `XmlnsDefinition`, so you can use the built-in `x` prefix with the **type name** of the extension (for example `x:Int32`, `x:Boolean`, `x:Guid`).

```xml
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Sample">
  <Button Content="Demo"
          CommandParameter="{x:Int32 42}"
          ToolTip="{x:Boolean True}" />
</Window>
```

Supported extensions include `Boolean`, `SByte`, `Byte`, `Int16`, `UInt16`, `Int32`, `UInt32`, `Int64`, `UInt64`, `Single`, `Double`, `Decimal`, `Char`, `Guid`, `DateTime`, `TimeSpan`, and `Enum` (via `EnumExtension`).

See **`Samples.WPF`** in this repository for more examples.

## Building & packing

- **Solution:** `MvvmAIO.Markup.slnx`
- **Pack both NuGet packages:** `dotnet pack MvvmAIO.Markup.Pack/MvvmAIO.Markup.Pack.csproj -c Release`
- **Nuke (CI parity):** `dotnet run --project build/_build.csproj -- --target Ci --configuration Release`

## Repository

<https://github.com/MvvmAIO/MvvmAIO.Markup>
