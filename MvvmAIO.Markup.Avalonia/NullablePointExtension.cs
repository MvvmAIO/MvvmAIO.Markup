namespace MvvmAIO.Markup;

public sealed class NullablePointExtension : MarkupExtension
{
    public NullablePointExtension(string value) => Value = MarkupValueParser.FromString<Point>(value);

    public NullablePointExtension() => Value = null;

    public Point? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}