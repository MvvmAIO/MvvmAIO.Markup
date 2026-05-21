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

**Shared (WPF + Avalonia):** `Boolean`, `True`, `False`, numeric primitives, `Char`, `Guid`, `DateTime`, `TimeSpan`, `String`, `Uri`, `CultureInfo`, and `Enum`.

**WPF / Avalonia (platform types):** `Thickness`, `Point`, `Size`, `Rect`, `Vector`, `GridLength`, `CornerRadius` — same `x:` syntax; implementations live in each platform assembly.

For **null** object parameters, use the built-in `{x:Null}` (these extensions are for explicit literals only).

Values that contain commas (for example `Point`, `Rect`, `pack://` URIs) must be passed as a **single quoted** constructor argument, e.g. `{x:Point '10,20'}`.

See **`Samples.WPF`** in this repository for more examples.

## Building & packing

- **Solution:** `MvvmAIO.Markup.slnx`
- **Pack both NuGet packages:** `dotnet pack MvvmAIO.Markup.Pack/MvvmAIO.Markup.Pack.csproj -c Release`
- **Nuke (CI parity):** `dotnet run --project build/_build.csproj -- --target Ci --configuration Release`

## Repository

<https://github.com/MvvmAIO/MvvmAIO.Markup>
