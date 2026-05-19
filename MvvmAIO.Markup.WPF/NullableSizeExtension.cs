namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(Size))]
public sealed class NullableSizeExtension : MarkupExtension
{
    public NullableSizeExtension(string value) => Value = MarkupValueParser.FromString<Size>(value);

    public NullableSizeExtension() => Value = null;

    public Size? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}