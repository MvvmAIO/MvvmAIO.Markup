# MvvmAIO.Markup

XAML markup extensions producing strongly typed CLR literals on the default `x` XML namespace (`MvvmAIO.Markup.WPF` and `MvvmAIO.Markup.Avalonia`). There are no source generators or runtime services. Consumer installation and syntax live in [`README.md`](README.md).

## Build & Verify

```powershell
# Recommended pre-PR gate (Clean -> Restore -> Compile -> Test -> Pack):
dotnet run --project build/_build.csproj -- --target Ci --configuration Release

# Quick build:
dotnet build MvvmAIO.Markup.slnx -c Release
```

- Requires **.NET 8** and **.NET 10** SDKs (`global.json` pins the 10.0 band).
- **Windows** is required to build WPF (`MvvmAIO.Markup.WPF` and `Samples.WPF`) and matches the `windows-latest` CI runner; Linux/macOS can only build Avalonia projects in isolation.

## Architecture & Invariants

- **Layout**: Portable CLR extensions live in `MvvmAIO.Markup.Shared/` (`MvvmAIO.Markup.Shared.projitems`); platform-specific extensions (`System.Windows` vs `Avalonia`) live in `MvvmAIO.Markup.WPF/` and `MvvmAIO.Markup.Avalonia/`. `MvvmAIO.Markup.Pack/` aggregates both NuGet packages via `Microsoft.Build.Traversal`.
- **Extension rules**: One `sealed` class per type under namespace `MvvmAIO.Markup`; shared primitives take the CLR type in their constructor; string-parsed platform types take `(string value)` and parse via `MarkupValueParser.FromString<T>` (`TypeDescriptor` + invariant culture); `EnumExtension` uses `Enum.Parse(..., ignoreCase: true)`.
- **Non-nullable return**: `ProvideValue` must return `object` (never `object?`) to match `MarkupExtension` without nullable override warnings.
- **WPF metadata**: Guard `[MarkupExtensionReturnType(typeof(T))]` with `#if WPF`. Both platforms expose `XmlnsDefinition` in `AssemblyInfo.cs`.
- **No nullable wrappers**: Do not add `Nullable*Extension` types; consumers should use `{x:Null}`.
- **Dependencies**: Manage versions centrally in [`Directory.Packages.props`](Directory.Packages.props); keep dependencies minimal and trim-friendly (`Polyfill` as `PrivateAssets`).

## Gotchas

- CI enables `TreatWarningsAsErrors=true`; nullable override mismatches on `ProvideValue` fail Avalonia `net10.0` builds.
- **Avalonia XAML**: Do not use `{x:Int32 ...}` brace syntax for shared CLR types (Avalonia resolves `System.Int32` before `Int32Extension`); use `<x:Int32>42</x:Int32>` object elements instead (platform types and built-in `{x:True}` / `{x:False}` work in braces; see `Samples.Avalonia/Views/MainWindow.axaml`).
- XAML values containing commas must be single-quoted (e.g., `{x:Point '10,20'}`).
- Root [`README.md`](README.md) is packed into both NuGet packages (`PackageReadmeFile`); keep it accurate when adding extensions.

## Repo-Specific Conventions

- Default branch is **`master`**; use **Squash and merge** for routine PRs.
- Commit messages, issues, and PR text: **English**.
- When adding an extension, extend `MvvmAIO.Markup.Tests.*`, add `Samples.WPF` / `Samples.Avalonia` coverage when behavior is non-obvious, and update [`README.md`](README.md).
- Version source of truth is [`Directory.Build.props`](Directory.Build.props) (`Version`); NuGet publishing runs on `v*` tags by authorized actors (`MvvmAIO`, `Skymly`, `wys0610`).
- Prefer `.slnx` (`MvvmAIO.Markup.slnx`); do not commit, push, bump versions, or create tags unless explicitly requested.
