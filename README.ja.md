# MvvmAIO.Markup

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語**

よく使われる CLR 型（真偽値、整数、`Guid`、`DateTime`、`TimeSpan`、`decimal`、`double`、`enum` など）向けの XAML **マークアップ拡張**です。共有実装は **WPF** と **Avalonia** の 2 つの NuGet パッケージとして提供されます。

## パッケージ

| パッケージ | 説明 |
|------------|------|
| [`MvvmAIO.Markup.WPF`](https://www.nuget.org/packages/MvvmAIO.Markup.WPF) | WPF（`UseWPF`）、.NET Framework 4.6.1 ～ .NET 10（Windows）マルチターゲット対応。 |
| [`MvvmAIO.Markup.Avalonia`](https://www.nuget.org/packages/MvvmAIO.Markup.Avalonia) | Avalonia 12、.NET 8 / 10 対応。 |

作者：**MvvmAIO**, **Skymly**, **wys0610**。ライセンス：**MIT**。

## インストール

```bash
dotnet add package MvvmAIO.Markup.WPF
# または
dotnet add package MvvmAIO.Markup.Avalonia
```

## 使い方（WPF / Avalonia）

本ライブラリは `XmlnsDefinition` により `MvvmAIO.Markup` を既定の XAML 名前空間 `xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"` にマッピングします。

### WPF

対応するすべての型で `{x:…}` マークアップ拡張を使用できます（例：`{x:Int32 42}`、`{x:True}`、`{x:Thickness 8}`）。

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

Avalonia はカスタム `{x:Int32 …}` マークアップ拡張より先に `x` 名前空間内の **CLR プリミティブ名**を解決します。以下の 2 つのパターンを使い分けてください（どちらも `x` プレフィックスを使用します）：

| 種類 | 構文 | 例 |
|------|------|----|
| 組み込み | `{x:True}`、`{x:False}`、`{x:Null}`、`{x:Type …}` | `CommandParameter="{x:True}"` |
| プラットフォーム拡張（本ライブラリ） | `{x:…}` マークアップ | `CommandParameter="{x:Thickness 8}"` |
| 共有 CLR リテラル | **オブジェクト要素**（`<x:Int32>…</x:Int32>` など） | 下記参照 |
| `Enum` / `CultureInfo` | `x:EnumExtension` / `x:CultureInfoExtension` と `x:Arguments` | **Samples.Avalonia** を参照 |

```xml
<Button Command="{Binding MyCommand}"
        CommandParameter="{x:Thickness 8}" />
<Button Command="{Binding MyCommand}">
  <Button.CommandParameter>
    <x:Int32>42</x:Int32>
  </Button.CommandParameter>
</Button>
```

属性構文では `{x:Boolean …}` よりも Avalonia 組み込みの `{x:True}` / `{x:False}` の使用を推奨します。

### マークアップ拡張一覧

| 拡張 | WPF | Avalonia | 備考 |
|------|:---:|:--------:|------|
| `Boolean` | ✓ | ✓ | WPF：`{x:Boolean True}`；Avalonia：`<x:Boolean>True</x:Boolean>` または組み込み `{x:True}` |
| `True` | ✓ | ✓ | WPF：`{x:True}`；Avalonia：組み込み `{x:True}` 推奨 |
| `False` | ✓ | ✓ | WPF：`{x:False}`；Avalonia：組み込み `{x:False}` 推奨 |
| `SByte`, `Byte`, `Int16`, `UInt16`, `Int32`, `UInt32`, `Int64`, `UInt64` | ✓ | ✓ | WPF：`{x:Int32 n}`；Avalonia：`<x:Int32>n</x:Int32>` |
| `Single`, `Double`, `Decimal` | ✓ | ✓ | WPF：`{x:…}`；Avalonia：`<x:…>` オブジェクト要素 |
| `Char` | ✓ | ✓ | |
| `Guid` | ✓ | ✓ | |
| `DateTime`, `TimeSpan` | ✓ | ✓ | InvariantCulture で解析 |
| `String` | ✓ | ✓ | |
| `Uri` | ✓ | ✓ | WPF ではカンマを含む値をクォート `{x:Uri '…'}` |
| `CultureInfo` | ✓ | ✓ | WPF：`{x:CultureInfo 'zh-CN'}`；Avalonia：`x:CultureInfoExtension` + `x:Arguments` |
| `Enum` | ✓ | ✓ | WPF：`{x:Enum {x:Type T},member}`；Avalonia：`x:EnumExtension` + `x:Arguments` |
| `Thickness` | ✓ | ✓ | `{x:Thickness 8}`（両プラットフォーム対応） |
| `Point`, `Size`, `Rect`, `Vector` | ✓ | ✓ | カンマ区切り — 値を**クォート**してください |
| `GridLength`, `CornerRadius` | ✓ | ✓ | |
| `Color` | ✓ | ✓ | `{x:Color '#FFFF0000'}` |
| `Duration`, `KeyTime` | ✓ | | WPF アニメーション（`System.Windows`） |

### Null と真偽値

| 構文 | 用途 |
|------|------|
| `{x:Null}` | `CommandParameter` や添付プロパティ向けの **Null** 参照（XAML 組み込みであり、本ライブラリの提供ではありません）。 |
| `{x:True}` / `{x:False}` | コンストラクター引数なしの **bool** リテラル短縮記法。 |
| `{x:Boolean True}` | `{x:True}` と同じ CLR 値（明示的な `Boolean` 拡張形式が必要な場合）。 |

本ライブラリは `Nullable*Extension` 型を**提供しません** — null 値には `{x:Null}` を使用してください。

### クォート付きコンストラクター引数

**カンマ**（または XAML トークン化を妨げる文字）を含む値は、**単一のクォート済み**引数として渡す必要があります：

```xml
CommandParameter="{x:Point '10,20'}"
CommandParameter="{x:Uri 'pack://application:,,,/Images/logo.png'}"
```

完全なボタンマトリックスは **`Samples.WPF`** および **`Samples.Avalonia`** を参照してください（WPF：すべて `{x:…}`；Avalonia：`{x:…}` + `<x:…>` 要素）。

## ビルドとパッケージング

- **ソリューション：** `MvvmAIO.Markup.slnx`
- **両 NuGet パッケージのパック：** `dotnet pack MvvmAIO.Markup.Pack/MvvmAIO.Markup.Pack.csproj -c Release`
- **Nuke（CI 同等）：** `dotnet run --project build/_build.csproj -- --target Ci --configuration Release`

## コントリビューション

コントリビューター向けガイドは **[AGENTS.md](AGENTS.md)**、**[CONTRIBUTING.md](CONTRIBUTING.md)**、**[CHANGELOG.md](CHANGELOG.md)** を参照してください。

## リポジトリ

<https://github.com/MvvmAIO/MvvmAIO.Markup>
