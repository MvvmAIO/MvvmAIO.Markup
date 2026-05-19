namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(Thickness))]
public sealed class ThicknessExtension : MarkupExtension
{
    public ThicknessExtension(string value) => Value = MarkupValueParser.FromString<Thickness>(value);

    public Thickness Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
