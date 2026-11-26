# MvvmAIO.Markup

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md)

針對常用 CLR 型別（布林值、整數、`Guid`、`DateTime`、`TimeSpan`、`decimal`、`double`、`enum` 等）的 XAML **標記延伸（Markup Extensions）**。共用實作透過兩個 NuGet 套件發布：**WPF** 與 **Avalonia**。

## NuGet 套件

| 套件名稱 | 說明 |
|----------|------|
| [`MvvmAIO.Markup.WPF`](https://www.nuget.org/packages/MvvmAIO.Markup.WPF) | WPF（`UseWPF`），多重目標涵蓋 .NET Framework 4.6.1 至 .NET 10（Windows）。 |
| [`MvvmAIO.Markup.Avalonia`](https://www.nuget.org/packages/MvvmAIO.Markup.Avalonia) | Avalonia 12，支援 .NET 8 / 10。 |

作者：**MvvmAIO**、**Skymly**、**wys0610**。授權條款：**MIT**。

## 安裝

```bash
dotnet add package MvvmAIO.Markup.WPF
# 或
dotnet add package MvvmAIO.Markup.Avalonia
```

## 用法（WPF / Avalonia）

本程式庫透過 `XmlnsDefinition` 將 `MvvmAIO.Markup` 對應至預設 XAML 命名空間 `xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"`。

### WPF

所有受支援的型別皆可直接使用 `{x:…}` 標記延伸（例如 `{x:Int32 42}`、`{x:True}`、`{x:Thickness 8}`）。

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

Avalonia 會在自訂 `{x:Int32 …}` 標記延伸之前優先解析 `x` 命名空間中的 **CLR 基本型別名稱**。請使用以下兩種寫法（均使用 `x` 前置詞）：

| 類別 | 語法 | 範例 |
|------|------|------|
| 內建語法 | `{x:True}`、`{x:False}`、`{x:Null}`、`{x:Type …}` | `CommandParameter="{x:True}"` |
| 平台延伸（本套件提供） | `{x:…}` 標記延伸 | `CommandParameter="{x:Thickness 8}"` |
| 共用 CLR 常值 | **物件項目**（`<x:Int32>…</x:Int32>` 等） | 見下方範例 |
| `Enum` / `CultureInfo` | `x:EnumExtension` / `x:CultureInfoExtension` 搭配 `x:Arguments` | 請參閱 **Samples.Avalonia** |

```xml
<Button Command="{Binding MyCommand}"
        CommandParameter="{x:Thickness 8}" />
<Button Command="{Binding MyCommand}">
  <Button.CommandParameter>
    <x:Int32>42</x:Int32>
  </Button.CommandParameter>
</Button>
```

在屬性寫法中，建議優先使用 Avalonia 內建的 `{x:True}` / `{x:False}`，而非 `{x:Boolean …}`。

### 支援的標記延伸

| 延伸類別 | WPF | Avalonia | 備註 |
|----------|:---:|:--------:|------|
| `Boolean` | ✓ | ✓ | WPF：`{x:Boolean True}`；Avalonia：`<x:Boolean>True</x:Boolean>` 或內建 `{x:True}` |
| `True` | ✓ | ✓ | WPF：`{x:True}`；Avalonia：建議使用內建 `{x:True}` |
| `False` | ✓ | ✓ | WPF：`{x:False}`；Avalonia：建議使用內建 `{x:False}` |
| `SByte`, `Byte`, `Int16`, `UInt16`, `Int32`, `UInt32`, `Int64`, `UInt64` | ✓ | ✓ | WPF：`{x:Int32 n}`；Avalonia：`<x:Int32>n</x:Int32>` |
| `Single`, `Double`, `Decimal` | ✓ | ✓ | WPF：`{x:…}`；Avalonia：`<x:…>` 物件項目 |
| `Char` | ✓ | ✓ | |
| `Guid` | ✓ | ✓ | |
| `DateTime`, `TimeSpan` | ✓ | ✓ | 使用不變文化特性（InvariantCulture）剖析 |
| `String` | ✓ | ✓ | |
| `Uri` | ✓ | ✓ | WPF 中含逗號的值需加引號 `{x:Uri '…'}` |
| `CultureInfo` | ✓ | ✓ | WPF：`{x:CultureInfo 'zh-CN'}`；Avalonia：`x:CultureInfoExtension` + `x:Arguments` |
| `Enum` | ✓ | ✓ | WPF：`{x:Enum {x:Type T},member}`；Avalonia：`x:EnumExtension` + `x:Arguments` |
| `Thickness` | ✓ | ✓ | `{x:Thickness 8}`（雙平台皆支援） |
| `Point`, `Size`, `Rect`, `Vector` | ✓ | ✓ | 逗號分隔值必須**加上引號** |
| `GridLength`, `CornerRadius` | ✓ | ✓ | |
| `Color` | ✓ | ✓ | `{x:Color '#FFFF0000'}` |
| `Duration`, `KeyTime` | ✓ | | WPF 動畫型別（`System.Windows`） |

### Null 與布林值

| 語法 | 適用情境 |
|------|----------|
| `{x:Null}` | 用於 `CommandParameter`、附加屬性等的 **null** 參考（XAML 內建，非本程式庫提供）。 |
| `{x:True}` / `{x:False}` | 無需建構函式引數的 **bool** 常值簡寫。 |
| `{x:Boolean True}` | 與 `{x:True}` 等價的 CLR 值，適用於需要明確使用 `Boolean` 延伸的情境。 |

本程式庫**不**提供 `Nullable*Extension` 型別 —— 空參考請使用 `{x:Null}`。

### 含引號的建構函式引數

包含**逗號**（或其他會中斷 XAML 權杖化的字元）的值必須作為**單一加引號**的引數傳入：

```xml
CommandParameter="{x:Point '10,20'}"
CommandParameter="{x:Uri 'pack://application:,,,/Images/logo.png'}"
```

完整按鈕範例矩陣請參閱 **`Samples.WPF`** 與 **`Samples.Avalonia`**（WPF：全部 `{x:…}`；Avalonia：`{x:…}` + `<x:…>` 項目）。

## 建置與封裝

- **解決方案：** `MvvmAIO.Markup.slnx`
- **封裝兩個 NuGet 套件：** `dotnet pack MvvmAIO.Markup.Pack/MvvmAIO.Markup.Pack.csproj -c Release`
- **Nuke（與 CI 一致）：** `dotnet run --project build/_build.csproj -- --target Ci --configuration Release`

## 參與貢獻

維護者與貢獻者請參閱 **[AGENTS.md](AGENTS.md)**、**[CONTRIBUTING.md](CONTRIBUTING.md)** 與 **[CHANGELOG.md](CHANGELOG.md)**。

## 儲存庫

<https://github.com/MvvmAIO/MvvmAIO.Markup>
