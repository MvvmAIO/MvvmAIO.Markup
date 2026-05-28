using Avalonia.Media;

namespace MvvmAIO.Markup;

public sealed class ColorExtension : MarkupExtension
{
    public ColorExtension(string value) => Value = Color.Parse(value);

    public Color Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
