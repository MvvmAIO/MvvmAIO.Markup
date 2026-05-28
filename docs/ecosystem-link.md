# MvvmAIO main repository — suggested README link

Use this block in [MvvmAIO/MvvmAIO](https://github.com/MvvmAIO/MvvmAIO) `README.md` (or docs) to point consumers at XAML literal markup extensions:

```markdown
### XAML literals (`MvvmAIO.Markup`)

Install **[MvvmAIO.Markup.WPF](https://www.nuget.org/packages/MvvmAIO.Markup.WPF)** or **[MvvmAIO.Markup.Avalonia](https://www.nuget.org/packages/MvvmAIO.Markup.Avalonia)** for strongly typed XAML literals on the `x` namespace. **WPF** uses `{x:Int32 42}`, `{x:True}`, `{x:Thickness 8}`, and similar markup extensions. **Avalonia** uses the same `x` prefix: `{x:…}` for platform types and built-in booleans; `<x:Int32>42</x:Int32>` object elements for shared CLR types (see package README).

Repository: <https://github.com/MvvmAIO/MvvmAIO.Markup>
```
