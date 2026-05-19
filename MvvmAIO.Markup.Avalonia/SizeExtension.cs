namespace MvvmAIO.Markup;

public sealed class SizeExtension : MarkupExtension
{
    public SizeExtension(string value) => Value = MarkupValueParser.FromString<Size>(value);

    public Size Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
