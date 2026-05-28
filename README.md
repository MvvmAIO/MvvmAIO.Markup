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

The library maps `MvvmAIO.Markup` into the default XAML namespace via `XmlnsDefinition` on `xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"`.

### WPF

Use `{x:…}` markup extensions for all supported types (for example `{x:Int32 42}`, `{x:True}`, `{x:Thickness 8}`).

```xml
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Sample">
  <Button Content="Demo"
          CommandParameter="{x:Int32 42}"
          ToolTip="{x:Boolean True}" />
</Window>
```

### Avalonia

Avalonia resolves **CLR primitive names** in the `x` namespace before custom `{x:Int32 …}` markup extensions. Use two patterns (both use the `x` prefix):

| Kind | Syntax | Example |
|------|--------|---------|
| Built-in | `{x:True}`, `{x:False}`, `{x:Null}`, `{x:Type …}` | `CommandParameter="{x:True}"` |
| Platform extensions (this library) | `{x:…}` markup | `CommandParameter="{x:Thickness 8}"` |
| Shared CLR literals | **Object elements** (`<x:Int32>…</x:Int32>`, etc.) | See below |
| `Enum` / `CultureInfo` | `x:EnumExtension` / `x:CultureInfoExtension` with `x:Arguments` | See **Samples.Avalonia** |

```xml
<Button Command="{Binding MyCommand}"
        CommandParameter="{x:Thickness 8}" />
<Button Command="{Binding MyCommand}">
  <Button.CommandParameter>
    <x:Int32>42</x:Int32>
  </Button.CommandParameter>
</Button>
```

Prefer Avalonia built-in `{x:True}` / `{x:False}` over `{x:Boolean …}` in attribute form.

### Markup extensions

| Extension | WPF | Avalonia | Notes |
|-----------|:---:|:--------:|-------|
| `Boolean` | ✓ | ✓ | WPF: `{x:Boolean True}`; Avalonia: `<x:Boolean>True</x:Boolean>` or built-in `{x:True}` |
| `True` | ✓ | ✓ | WPF: `{x:True}`; Avalonia: prefer built-in `{x:True}` |
| `False` | ✓ | ✓ | WPF: `{x:False}`; Avalonia: prefer built-in `{x:False}` |
| `SByte`, `Byte`, `Int16`, `UInt16`, `Int32`, `UInt32`, `Int64`, `UInt64` | ✓ | ✓ | WPF: `{x:Int32 n}`; Avalonia: `<x:Int32>n</x:Int32>` |
| `Single`, `Double`, `Decimal` | ✓ | ✓ | WPF: `{x:…}`; Avalonia: `<x:…>` object element |
| `Char` | ✓ | ✓ | |
| `Guid` | ✓ | ✓ | |
| `DateTime`, `TimeSpan` | ✓ | ✓ | Invariant culture parsing |
| `String` | ✓ | ✓ | |
| `Uri` | ✓ | ✓ | Quote comma values in WPF `{x:Uri '…'}` |
| `CultureInfo` | ✓ | ✓ | WPF: `{x:CultureInfo 'zh-CN'}`; Avalonia: `x:CultureInfoExtension` + `x:Arguments` |
| `Enum` | ✓ | ✓ | WPF: `{x:Enum {x:Type T},member}`; Avalonia: `x:EnumExtension` + `x:Arguments` |
| `Thickness` | ✓ | ✓ | `{x:Thickness 8}` (both platforms) |
| `Point`, `Size`, `Rect`, `Vector` | ✓ | ✓ | Comma-separated — **quote** the value |
| `GridLength`, `CornerRadius` | ✓ | ✓ | |
| `Color` | ✓ | ✓ | `{x:Color '#FFFF0000'}` |
| `Duration`, `KeyTime` | ✓ | | WPF animation (`System.Windows`) |

### Null and booleans

| Syntax | When to use |
|--------|-------------|
| `{x:Null}` | **Null** reference for `CommandParameter`, attached properties, etc. (built-in XAML; not provided by this library). |
| `{x:True}` / `{x:False}` | Shorthand **bool** literals without a constructor argument. |
| `{x:Boolean True}` | Same CLR value as `{x:True}`, when you need the explicit `Boolean` extension form. |

This library does **not** ship `Nullable*Extension` types — use `{x:Null}` for null.

### Quoted constructor arguments

Values that contain **commas** (or other characters that break XAML tokenization) must be a **single quoted** argument:

```xml
CommandParameter="{x:Point '10,20'}"
CommandParameter="{x:Uri 'pack://application:,,,/Images/logo.png'}"
```

See **`Samples.WPF`** and **`Samples.Avalonia`** for full button matrices (WPF: all `{x:…}`; Avalonia: `{x:…}` + `<x:…>` elements).

## Building & packing

- **Solution:** `MvvmAIO.Markup.slnx`
- **Pack both NuGet packages:** `dotnet pack MvvmAIO.Markup.Pack/MvvmAIO.Markup.Pack.csproj -c Release`
- **Nuke (CI parity):** `dotnet run --project build/_build.csproj -- --target Ci --configuration Release`

## Contributing

Automated agents and contributors: see **[AGENTS.md](AGENTS.md)** ([中文摘要](AGENTS.zh-CN.md)), **[CONTRIBUTING.md](CONTRIBUTING.md)**, and **[CHANGELOG.md](CHANGELOG.md)**.

## Repository

<https://github.com/MvvmAIO/MvvmAIO.Markup>
