using System.Windows.Media;

namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(Color))]
public sealed class ColorExtension : MarkupExtension
{
    public ColorExtension(string value) => Value = MarkupValueParser.FromString<Color>(value);

    public Color Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
