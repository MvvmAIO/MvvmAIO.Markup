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

The library maps `MvvmAIO.Markup` into the default XAML namespace via `XmlnsDefinition`.

- **WPF:** use the built-in `x` prefix with the extension type name (for example `{x:Int32 42}`, `{x:True}`).
- **Avalonia:** the `x` prefix can resolve to CLR primitives (`System.Int32`, etc.) before custom extensions. Declare `xmlns:m="using:MvvmAIO.Markup"` and use `{m:Int32 42}`, `{m:True}`, and so on. Built-in `{x:Null}` and `{x:Type …}` stay on `x`.

```xml
<Window xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Sample">
  <Button Content="Demo"
          CommandParameter="{x:Int32 42}"
          ToolTip="{x:Boolean True}" />
</Window>
```

### Markup extensions

| Extension | WPF | Avalonia | Notes |
|-----------|:---:|:--------:|-------|
| `Boolean` | ✓ | ✓ | `{x:Boolean True}` — constructor argument required |
| `True` | ✓ | ✓ | `{x:True}` — parameterless |
| `False` | ✓ | ✓ | `{x:False}` — parameterless |
| `SByte`, `Byte`, `Int16`, `UInt16`, `Int32`, `UInt32`, `Int64`, `UInt64` | ✓ | ✓ | Integer literals |
| `Single`, `Double`, `Decimal` | ✓ | ✓ | Floating-point literals |
| `Char` | ✓ | ✓ | Single character |
| `Guid` | ✓ | ✓ | |
| `DateTime`, `TimeSpan` | ✓ | ✓ | Invariant culture parsing |
| `String` | ✓ | ✓ | |
| `Uri` | ✓ | ✓ | Quote values with commas or special characters |
| `CultureInfo` | ✓ | ✓ | e.g. `{x:CultureInfo 'zh-CN'}` |
| `Enum` | ✓ | ✓ | `{x:Enum {x:Type MyEnum},member}` — case-insensitive |
| `Thickness` | ✓ | ✓ | String constructor, e.g. `{x:Thickness 8}` |
| `Point`, `Size`, `Rect`, `Vector` | ✓ | ✓ | Comma-separated — **quote** the value |
| `GridLength`, `CornerRadius` | ✓ | ✓ | |

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

See **`Samples.WPF`** (`{x:…}`) and **`Samples.Avalonia`** (`xmlns:m` + `{m:…}`) for full button matrices.

## Building & packing

- **Solution:** `MvvmAIO.Markup.slnx`
- **Pack both NuGet packages:** `dotnet pack MvvmAIO.Markup.Pack/MvvmAIO.Markup.Pack.csproj -c Release`
- **Nuke (CI parity):** `dotnet run --project build/_build.csproj -- --target Ci --configuration Release`

## Contributing

Automated agents and contributors: see **[AGENTS.md](AGENTS.md)** ([中文摘要](AGENTS.zh-CN.md)), **[CONTRIBUTING.md](CONTRIBUTING.md)**, and **[CHANGELOG.md](CHANGELOG.md)**.

## Repository

<https://github.com/MvvmAIO/MvvmAIO.Markup>
