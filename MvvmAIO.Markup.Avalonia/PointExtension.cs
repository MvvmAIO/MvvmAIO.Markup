namespace MvvmAIO.Markup;

public sealed class PointExtension : MarkupExtension
{
    public PointExtension(string value) => Value = MarkupValueParser.FromString<Point>(value);

    public Point Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
