namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(Thickness))]
public sealed class NullableThicknessExtension : MarkupExtension
{
    public NullableThicknessExtension(string value) => Value = MarkupValueParser.FromString<Thickness>(value);

    public NullableThicknessExtension() => Value = null;

    public Thickness? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}