# Contributing to MvvmAIO.Markup

Thank you for your interest in this project.

**Automated agents (Cursor, cloud agents):** the canonical constraint document is **[AGENTS.md](AGENTS.md)** at the repository root. `.cursor/rules/` defers to it.

---

## Ground rules

- Open **pull requests against `master`**. Link related issues when applicable (`Fixes #NN`, `Closes #NN`).
- Maintainers merge with **Squash and merge** for routine PRs.
- **CI must pass** before merge unless a maintainer agrees to an exception.
- **Do not** commit secrets. **Do not** create git commits or tags unless you are explicitly asked (agents).

---

## Development environment

| Requirement | Notes |
|-------------|--------|
| **.NET 10 SDK** | Required; see [`global.json`](global.json). |
| **.NET 8 SDK** | Avalonia `net8.0` targets. |
| **Windows** | Full solution build (WPF + samples). CI uses `windows-latest`. |
| **IDE** | Visual Studio 2022+, Rider, or VS Code — entry solution is **`MvvmAIO.Markup.slnx`**. |

```bash
git clone https://github.com/MvvmAIO/MvvmAIO.Markup.git
cd MvvmAIO.Markup
dotnet build MvvmAIO.Markup.slnx
```

---

## Build and test

**Full CI** (recommended before a PR):

```bash
dotnet run --project build/_build.csproj -- --target Ci --configuration Release
```

**Pack** (both NuGet packages):

```bash
dotnet pack MvvmAIO.Markup.Pack/MvvmAIO.Markup.Pack.csproj -c Release
```

---

## Adding markup extensions

See **[AGENTS.md](AGENTS.md)** — sections *Markup extension conventions*, *Repository layout*, and *Mandatory project rules*.

Update **[README.md](README.md)**, **[CHANGELOG.md](CHANGELOG.md)** (Unreleased), and samples when behavior is user-visible.

---

## Release

Maintainers bump **`Version`** in [`Directory.Build.props`](Directory.Build.props), run **Ci**, tag **`v*`** to trigger NuGet publish. See [AGENTS.md](AGENTS.md) and [`.github/workflows/nuget-publish.yml`](.github/workflows/nuget-publish.yml).
