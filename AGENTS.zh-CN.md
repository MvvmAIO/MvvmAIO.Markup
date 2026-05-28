# AGENTS.zh-CN.md

面向中文贡献者与自动化代理的**摘要**。[**AGENTS.md**](AGENTS.md)（英文）为唯一 canonical 约束全文；若冲突以英文为准。

## 项目是什么

为 MVVM 场景提供 XAML **字面量 Markup 扩展**，通过 `XmlnsDefinition` 挂到 `xmlns:x`（winfx/2006/xaml）。两个 NuGet 包：**MvvmAIO.Markup.WPF**、**MvvmAIO.Markup.Avalonia**。

- **WPF：** 属性上统一用 `{x:Int32 42}`、`{x:True}` 等花括号写法。
- **Avalonia：** 平台类型用 `{x:Thickness 8}` 等花括号；内置 `{x:True}`/`{x:False}`；共享 CLR 字面量用 `<x:Int32>42</x:Int32>` 对象元素（勿对整型等使用 `{x:Int32 …}` 属性形式，会与 `System.Int32` 冲突）。详见 **Samples.Avalonia** 与 **README.md**。

## 本地构建

```bash
dotnet run --project build/_build.csproj -- --target Ci --configuration Release
```

需 **Windows** 做全量构建（含 WPF）。版本在 `Directory.Build.props`。

## 关键约定

- 扩展用于**明确字面量**；`null` 用内置 **`{x:Null}`**，不要加 `Nullable*Extension`。
- `ProvideValue` 返回 **`object`**（不要用 `object?`，CI 会 CS8764）。
- 含逗号的参数需引号：`{x:Point '10,20'}`。
- Avalonia 示例与文档统一 **`x:`** 前缀，不再使用 `xmlns:m`。
- 解决方案用 **`.slnx`**；临时实验放 **`.Temp/`**（勿提交）。

完整目录、扩展清单与 CI 说明见 [**AGENTS.md**](AGENTS.md)。
