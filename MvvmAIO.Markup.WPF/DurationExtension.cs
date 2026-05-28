using System.Windows;

namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(Duration))]
public sealed class DurationExtension : MarkupExtension
{
    public DurationExtension(string value) => Value = MarkupValueParser.FromString<Duration>(value);

    public Duration Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
