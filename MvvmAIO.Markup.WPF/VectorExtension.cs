namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(Vector))]
public sealed class VectorExtension : MarkupExtension
{
    public VectorExtension(string value) => Value = MarkupValueParser.FromString<Vector>(value);

    public Vector Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
