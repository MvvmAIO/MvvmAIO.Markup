# MvvmAIO.Markup

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md)

面向常用 CLR 类型（布尔值、整数、`Guid`、`DateTime`、`TimeSpan`、`decimal`、`double`、`enum` 等）的 XAML **标记扩展**。共享实现通过两个 NuGet 包分发：**WPF** 与 **Avalonia**。

## NuGet 包

| 包名 | 说明 |
|------|------|
| [`MvvmAIO.Markup.WPF`](https://www.nuget.org/packages/MvvmAIO.Markup.WPF) | WPF（`UseWPF`），多目标覆盖 .NET Framework 4.6.1 至 .NET 10（Windows）。 |
| [`MvvmAIO.Markup.Avalonia`](https://www.nuget.org/packages/MvvmAIO.Markup.Avalonia) | Avalonia 12，支持 .NET 8 / 10。 |

作者：**MvvmAIO**、**Skymly**、**wys0610**。许可证：**MIT**。

## 安装

```bash
dotnet add package MvvmAIO.Markup.WPF
# 或
dotnet add package MvvmAIO.Markup.Avalonia
```

## 用法（WPF / Avalonia）

本库通过 `XmlnsDefinition` 将 `MvvmAIO.Markup` 映射到默认 XAML 命名空间 `xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"`。

### WPF

所有受支持类型均可直接使用 `{x:…}` 标记扩展（例如 `{x:Int32 42}`、`{x:True}`、`{x:Thickness 8}`）。

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

Avalonia 会在自定义 `{x:Int32 …}` 标记扩展之前优先解析 `x` 命名空间中的 **CLR 基元名称**。请使用以下两种写法（均使用 `x` 前缀）：

| 类别 | 语法 | 示例 |
|------|------|------|
| 内置语法 | `{x:True}`、`{x:False}`、`{x:Null}`、`{x:Type …}` | `CommandParameter="{x:True}"` |
| 平台扩展（本库提供） | `{x:…}` 标记扩展 | `CommandParameter="{x:Thickness 8}"` |
| 共享 CLR 字面量 | **对象元素**（`<x:Int32>…</x:Int32>` 等） | 见下方示例 |
| `Enum` / `CultureInfo` | `x:EnumExtension` / `x:CultureInfoExtension` 搭配 `x:Arguments` | 见 **Samples.Avalonia** |

```xml
<Button Command="{Binding MyCommand}"
        CommandParameter="{x:Thickness 8}" />
<Button Command="{Binding MyCommand}">
  <Button.CommandParameter>
    <x:Int32>42</x:Int32>
  </Button.CommandParameter>
</Button>
```

在属性写法中，建议优先使用 Avalonia 内置的 `{x:True}` / `{x:False}` 而非 `{x:Boolean …}`。

### 支持的标记扩展

| 扩展 | WPF | Avalonia | 说明 |
|------|:---:|:--------:|------|
| `Boolean` | ✓ | ✓ | WPF：`{x:Boolean True}`；Avalonia：`<x:Boolean>True</x:Boolean>` 或内置 `{x:True}` |
| `True` | ✓ | ✓ | WPF：`{x:True}`；Avalonia：优先使用内置 `{x:True}` |
| `False` | ✓ | ✓ | WPF：`{x:False}`；Avalonia：优先使用内置 `{x:False}` |
| `SByte`, `Byte`, `Int16`, `UInt16`, `Int32`, `UInt32`, `Int64`, `UInt64` | ✓ | ✓ | WPF：`{x:Int32 n}`；Avalonia：`<x:Int32>n</x:Int32>` |
| `Single`, `Double`, `Decimal` | ✓ | ✓ | WPF：`{x:…}`；Avalonia：`<x:…>` 对象元素 |
| `Char` | ✓ | ✓ | |
| `Guid` | ✓ | ✓ | |
| `DateTime`, `TimeSpan` | ✓ | ✓ | 不变文化（InvariantCulture）解析 |
| `String` | ✓ | ✓ | |
| `Uri` | ✓ | ✓ | WPF 中含逗号的值需加引号 `{x:Uri '…'}` |
| `CultureInfo` | ✓ | ✓ | WPF：`{x:CultureInfo 'zh-CN'}`；Avalonia：`x:CultureInfoExtension` + `x:Arguments` |
| `Enum` | ✓ | ✓ | WPF：`{x:Enum {x:Type T},member}`；Avalonia：`x:EnumExtension` + `x:Arguments` |
| `Thickness` | ✓ | ✓ | `{x:Thickness 8}`（双平台均支持） |
| `Point`, `Size`, `Rect`, `Vector` | ✓ | ✓ | 逗号分隔值必须**加引号** |
| `GridLength`, `CornerRadius` | ✓ | ✓ | |
| `Color` | ✓ | ✓ | `{x:Color '#FFFF0000'}` |
| `Duration`, `KeyTime` | ✓ | | WPF 动画类型（`System.Windows`） |

### Null 与布尔值

| 语法 | 适用场景 |
|------|----------|
| `{x:Null}` | 用于 `CommandParameter`、附加属性等的 **null** 引用（XAML 内置，非本库提供）。 |
| `{x:True}` / `{x:False}` | 无需构造参数的 **bool** 字面量简写。 |
| `{x:Boolean True}` | 与 `{x:True}` 等价的 CLR 值，适用于需要显式 `Boolean` 扩展的场景。 |

本库**不**提供 `Nullable*Extension` 类型 —— 空引用请使用 `{x:Null}`。

### 带引号的构造参数

包含**逗号**（或其他会打断 XAML 分词的字符）的参数值必须作为**单个带引号**参数传入：

```xml
CommandParameter="{x:Point '10,20'}"
CommandParameter="{x:Uri 'pack://application:,,,/Images/logo.png'}"
```

完整按钮示例矩阵见 **`Samples.WPF`** 与 **`Samples.Avalonia`**（WPF：全部 `{x:…}`；Avalonia：`{x:…}` + `<x:…>` 元素）。

## 构建与打包

- **解决方案：** `MvvmAIO.Markup.slnx`
- **同时打包两个 NuGet 包：** `dotnet pack MvvmAIO.Markup.Pack/MvvmAIO.Markup.Pack.csproj -c Release`
- **Nuke（与 CI 一致）：** `dotnet run --project build/_build.csproj -- --target Ci --configuration Release`

## 参与贡献

维护者与贡献者请阅读 **[AGENTS.md](AGENTS.md)**、**[CONTRIBUTING.md](CONTRIBUTING.md)** 与 **[CHANGELOG.md](CHANGELOG.md)**。

## 仓库地址

<https://github.com/MvvmAIO/MvvmAIO.Markup>
