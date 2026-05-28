# AGENTS.zh-CN.md

面向中文贡献者与自动化代理的**摘要**。[**AGENTS.md**](AGENTS.md)（英文）为唯一 canonical 约束全文；若冲突以英文为准。

## 项目是什么

为 MVVM 场景提供 XAML **字面量 Markup 扩展**（`{x:Int32 42}`、`{x:True}` 等），通过 `XmlnsDefinition` 挂到默认 `x` 命名空间。两个 NuGet 包：**MvvmAIO.Markup.WPF**、**MvvmAIO.Markup.Avalonia**。

## 本地构建

```bash
dotnet run --project build/_build.csproj -- --target Ci --configuration Release
```

需 **Windows** 做全量构建（含 WPF）。版本在 `Directory.Build.props`。

## 关键约定

- 扩展用于**明确字面量**；`null` 用内置 **`{x:Null}`**，不要加 `Nullable*Extension`。
- `ProvideValue` 返回 **`object`**（不要用 `object?`，CI 会 CS8764）。
- 含逗号的参数需引号：`{x:Point '10,20'}`。
- 解决方案用 **`.slnx`**；临时实验放 **`.Temp/`**（勿提交）。

完整目录、扩展清单与 CI 说明见 [**AGENTS.md**](AGENTS.md)。
