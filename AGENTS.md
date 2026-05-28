# AGENTS.md

**Canonical project constraints** for human contributors and automated agents (Cursor, cloud agents, CI bots). Follow this file for all work in **MvvmAIO/MvvmAIO.Markup**. If [`.cursor/rules/`](.cursor/rules/) is added later, those rules must defer here and must not contradict this document.

For **consumer-facing** installation and XAML syntax, **[README.md](README.md)** is authoritative; this file governs **how to change the repository**.

---

## Project overview

**XAML markup extensions** that produce strongly typed **CLR literals** for MVVM scenarios (`CommandParameter`, attached properties, resources, etc.). Types are exposed on the default **`x`** namespace via `XmlnsDefinition` — consumers write `{x:Int32 42}`, `{x:True}`, `{x:Thickness 8}`, not custom XML namespaces.

| NuGet package | Role |
|---------------|------|
| **MvvmAIO.Markup.WPF** | WPF (`UseWPF`); `net461`–`net10.0-windows` |
| **MvvmAIO.Markup.Avalonia** | Avalonia 12; `net8.0` / `net10.0` |

There are **no** source generators, runtime services, or databases. Validation is **`dotnet build`**, **`Samples.WPF`**, and the Nuke **Ci** target.

**Related repositories** (separate clones):

| Repo | Role |
|------|------|
| [MvvmAIO](https://github.com/MvvmAIO/MvvmAIO) | Core MVVM stack |
| [Prism.SourceGenerators](https://github.com/MvvmAIO/Prism.SourceGenerators) | Prism Roslyn generators (same Nuke / SLNX / CI patterns) |
| [MvvmAIO.R3.SourceGenerators](https://github.com/MvvmAIO/MvvmAIO.R3.SourceGenerators) | R3 event/command generators |

---

## Development environment

| Requirement | Notes |
|-------------|--------|
| **.NET 10 SDK** | Required for Nuke `build/` and `net10` targets; pinned in [`global.json`](global.json) (`10.0.201`, `rollForward: latestFeature`) |
| **.NET 8 SDK** | Avalonia `net8.0` and CI |
| **Windows** | **Required** for full solution build (WPF + `Samples.WPF`). Linux/macOS can build **Avalonia-only** projects in isolation, but CI and Nuke **Ci** run on **`windows-latest`**. |
| **IDE** | Visual Studio 2022+, Rider, or VS Code + C# Dev Kit — entry solution is **[`MvvmAIO.Markup.slnx`](MvvmAIO.Markup.slnx)** |

---

## Build, test, and release

| Task | Command |
|------|---------|
| Restore | `dotnet restore MvvmAIO.Markup.slnx` |
| Build | `dotnet build MvvmAIO.Markup.slnx -c Release` |
| **Full CI** (recommended before PR) | `dotnet run --project build/_build.csproj -- --target Ci --configuration Release` |
| Pack (both packages) | `dotnet pack MvvmAIO.Markup.Pack/MvvmAIO.Markup.Pack.csproj -c Release` |
| Publish NuGet | Tag `v<VER>` or workflow **Publish NuGet** (maintainer actors + `NUGET_API_KEY`) |

Nuke **Ci** = `Clean` → `Restore` → `Compile` (`TreatWarningsAsErrors=true`) → `Pack` (Traversal project packs WPF + Avalonia). There is **no** `Test` target yet.

Package version: **[`Directory.Build.props`](Directory.Build.props)** `Version` (overridden on publish via `--version` / tag).

---

## Repository layout

| Path | Purpose |
|------|---------|
| `MvvmAIO.Markup.Shared/` | Shared markup extensions (`.shproj` + `.projitems`) |
| `MvvmAIO.Markup.WPF/` | WPF-only extensions + `MarkupValueParser`; imports Shared with `WPF` constant |
| `MvvmAIO.Markup.Avalonia/` | Avalonia-only extensions + `MarkupValueParser`; imports Shared with `Avalonia` constant |
| `MvvmAIO.Markup.Pack/` | [Microsoft.Build.Traversal](https://www.nuget.org/packages/Microsoft.Build.Traversal) — aggregates pack of both libraries |
| `Samples.WPF/` | Interactive demo (not packed) |
| `build/` | Nuke — `build/_build.csproj`, [`.nuke/`](.nuke/) parameters schema |
| `.github/workflows/` | `dotnet.yml` (CI on `master`), `nuget-publish.yml` (tags `v*`) |

When adding a **shared** type, edit **`MvvmAIO.Markup.Shared.projitems`** and add the `.cs` file under `MvvmAIO.Markup.Shared/`. Platform-specific types go only in **WPF** and/or **Avalonia** project folders (duplicate names are fine; types differ by `System.Windows` vs `Avalonia`).

---

## Markup extension conventions

### Shared primitives (example: `Int32Extension`)

- One **sealed** class per type, namespace **`MvvmAIO.Markup`**.
- Constructor takes the **CLR value** (XAML type converter supplies the literal).
- `ProvideValue` returns **`object`**, not `object?` — must match `MarkupExtension` base (CI treats warnings as errors on Avalonia `net10`).
- WPF only: `[MarkupExtensionReturnType(typeof(T))]` under `#if WPF`. Avalonia has no equivalent attribute in this repo; omit on Avalonia-only files.

### Shorthand booleans

- **`TrueExtension`** / **`FalseExtension`**: parameterless; return `true` / `false`.
- **`BooleanExtension`**: `{x:Boolean True}` when a constructor argument is required.

### String-parsed platform types (WPF / Avalonia)

- Constructor: **`(string value)`** → parse via **`MarkupValueParser.FromString<T>`** (`TypeDescriptor` + invariant culture).
- Examples: `Thickness`, `Point`, `Rect`, `GridLength`, etc.
- XAML values with **commas** must be **one quoted** argument: `{x:Point '10,20'}` (document in README / samples).

### Enum

- **`EnumExtension`**: `{x:Enum {x:Type SomeEnum}, memberName}` — `Enum.Parse(..., ignoreCase: true)`.

### Null

- **Do not** add `Nullable*Extension` types. Use built-in **`{x:Null}`** for null object parameters. Markup extensions here are for **explicit literals** only.

### Xmlns

- Both platforms: `[assembly: XmlnsDefinition("http://schemas.microsoft.com/winfx/2006/xaml", "MvvmAIO.Markup")]` in `AssemblyInfo.cs`.

---

## Current extension inventory

**Shared (WPF + Avalonia):** `Boolean`, `True`, `False`, `SByte`, `Byte`, `Int16`, `UInt16`, `Int32`, `UInt32`, `Int64`, `UInt64`, `Single`, `Double`, `Decimal`, `Char`, `Guid`, `DateTime`, `TimeSpan`, `String`, `Uri`, `CultureInfo`, `Enum`.

**Per platform (WPF + Avalonia each):** `Thickness`, `Point`, `Size`, `Rect`, `Vector`, `GridLength`, `CornerRadius`.

When adding types (e.g. `Color`, `Duration`), decide **Shared** vs **platform project** by whether the CLR type is portable.

---

## Mandatory project rules

### 1. Solution format — prefer SLNX over SLN

- Use **[`MvvmAIO.Markup.slnx`](MvvmAIO.Markup.slnx)** as the primary solution.
- Prefer **`dotnet new slnx`** when creating solutions from scratch.
- **Do not** add a legacy `.sln` unless the user explicitly requests it.

### 2. Temporary files and scratch work — `.Temp/`

- Place throwaway `dotnet new` apps and local experiments under repository root **`.Temp/`**.
- **Do not commit** `.Temp/` (add to `.gitignore` if missing).
- Nothing in CI or product build may depend on `.Temp/`.

### 3. Git and GitHub workflow

1. **Issue** — Open or reference a GitHub issue before large changes when appropriate.
2. **Pull request** — Branch → PR to **`master`**; link issue when applicable.
3. **Merge** — **Squash and merge** for routine PRs unless a maintainer says otherwise.
4. **CI** — Must be green before merge (`windows-latest`, Nuke **Ci**).

Additional expectations:

- **Do not** commit secrets (`NUGET_API_KEY`, PATs).
- **Do not** run destructive git on `master` unless explicitly requested.
- **Do not** create git commits, tags, or pushes unless the user explicitly asks.

Publish actors (workflow `if:`): **`MvvmAIO`**, **`Skymly`**, **`wys0610`**.

### 4. Code and review expectations

- Match existing style in touched files (`LangVersion` 14, nullable enabled on library projects).
- **Minimal scope** — one logical concern per change; no drive-by refactors.
- New extensions: add **Samples.WPF** buttons when behavior is non-obvious; update **README.md** extension list.
- **User-visible** releases: bump **`Directory.Build.props`** `Version`; tag **`v*`** for NuGet publish.
- **Tests:** none today; when a test project is added, wire it into Nuke **Ci** — prefer testing `ProvideValue` and parsing edge cases.

### 5. Dependencies

- **`Polyfill`** (PrivateAssets) on WPF/Avalonia projects — keep versions aligned across projects.
- **Avalonia** package version is declared in `MvvmAIO.Markup.Avalonia.csproj` only.
- Do not add heavy dependencies; this library should stay small and trim-friendly.

---

## CI and packaging gotchas

- CI uses **`TreatWarningsAsErrors=true`** via Nuke — nullable override mismatches on `ProvideValue` **fail** the build (see v0.1.1 CI history).
- **WPF** forces **`windows-latest`** runners; do not switch CI to `ubuntu-latest` without dropping WPF from the solution graph.
- Pack output: `MvvmAIO.Markup.WPF/bin/Release/*.nupkg` and `MvvmAIO.Markup.Avalonia/bin/Release/*.nupkg`.
- Root **README.md** is packed into both NuGet packages (`PackageReadmeFile`).
- **`LICENSE.txt`** still contains placeholder copyright text — fix before a formal legal audit.

---

## Suggested follow-ups (not blockers for routine PRs)

| Area | Notes |
|------|--------|
| Unit tests | `ProvideValue` + `MarkupValueParser` + enum parsing |
| `Samples.Avalonia` | Parity with WPF sample matrix |
| `CHANGELOG.md` | Release notes for 0.1.x |
| `CONTRIBUTING.md` | Short pointer to this file |
| `.cursor/rules/` | Thin rules that link to **AGENTS.md** only (Prism pattern) |
| Medium-priority extensions | `Color`, `Duration` — platform-specific if added |

---

## Documentation map

| Surface | Use for |
|---------|---------|
| **[README.md](README.md)** | Install, syntax, extension list, quoting rules |
| **This file** | Agent/contributor constraints, layout, CI, conventions |
| **[Samples.WPF/Views/MainWindow.xaml](Samples.WPF/Views/MainWindow.xaml)** | Living examples for most extensions |

---

## Cursor Cloud notes

Install **.NET 8** and **.NET 10** SDKs before building. Run Nuke **Ci** on **Windows** (or accept that full validation matches GitHub Actions). Use **`.Temp/`** for spikes only.
