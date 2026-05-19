namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(Rect))]
public sealed class RectExtension : MarkupExtension
{
    public RectExtension(string value) => Value = MarkupValueParser.FromString<Rect>(value);

    public Rect Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
