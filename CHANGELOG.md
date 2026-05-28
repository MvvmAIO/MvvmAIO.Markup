# Changelog

All notable changes to this project are documented in this file.

## Unreleased

## [0.2.0] - 2026-05-19

### Added

- **Unit tests:** `MvvmAIO.Markup.Tests.WPF` and `MvvmAIO.Markup.Tests.Avalonia`; Nuke **Test** target runs before **Pack** in **Ci**.
- **`Samples.Avalonia`** — interactive demo aligned with **Samples.WPF**.
- **`CHANGELOG.md`**, **`CONTRIBUTING.md`**, **`AGENTS.zh-CN.md`**, **`.cursor/rules/agents.mdc`**.
- README extension tables, `{x:Null}` / boolean shorthand notes, and links to contributing docs.

### Changed

- **`LICENSE.txt`** — copyright line set to **MvvmAIO** (MIT).
- **`EnumExtension`** — `sealed`, WPF `[MarkupExtensionReturnType]`, consistent with other shared extensions.
- **Avalonia `MarkupValueParser`** — uses platform `Parse` methods for geometry types when `TypeConverter` cannot convert from `string`.

## [0.1.3] - 2026-05-18

### Removed

- All **`Nullable*Extension`** types; use built-in **`{x:Null}`** for null object parameters.

### Fixed

- **`ProvideValue`** return type must be **`object`**, not **`object?`** (Avalonia `net10` + `TreatWarningsAsErrors` → CS8764).

## [0.1.2] - 2026-05-18

### Added

- **`TrueExtension`** / **`FalseExtension`** — parameterless `{x:True}` and `{x:False}`.

## [0.1.1] - 2026-05-18

### Added

- **`Nullable*Extension`** for reference and value types (later removed in 0.1.3).

## [0.1.0] - 2026-05-18

### Added

- Initial **MvvmAIO.Markup.WPF** and **MvvmAIO.Markup.Avalonia** packages.
- Shared CLR markup extensions (`Int32`, `Boolean`, `Guid`, `DateTime`, `Enum`, etc.).
- Platform extensions: `Thickness`, `Point`, `Size`, `Rect`, `Vector`, `GridLength`, `CornerRadius`.
- **`StringExtension`**, **`UriExtension`**, **`CultureInfoExtension`**.
- Nuke **Ci** / **Publish**, GitHub Actions, **`Samples.WPF`**, **`MvvmAIO.Markup.Pack`** traversal project.
