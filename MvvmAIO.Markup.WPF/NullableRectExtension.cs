namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(Rect))]
public sealed class NullableRectExtension : MarkupExtension
{
    public NullableRectExtension(string value) => Value = MarkupValueParser.FromString<Rect>(value);

    public NullableRectExtension() => Value = null;

    public Rect? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}