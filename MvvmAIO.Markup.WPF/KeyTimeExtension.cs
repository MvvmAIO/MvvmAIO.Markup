using System.Windows.Media.Animation;

namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(KeyTime))]
public sealed class KeyTimeExtension : MarkupExtension
{
    public KeyTimeExtension(string value) => Value = MarkupValueParser.FromString<KeyTime>(value);

    public KeyTime Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
