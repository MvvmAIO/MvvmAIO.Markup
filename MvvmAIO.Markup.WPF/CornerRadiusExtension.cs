namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(CornerRadius))]
public sealed class CornerRadiusExtension : MarkupExtension
{
    public CornerRadiusExtension(string value) => Value = MarkupValueParser.FromString<CornerRadius>(value);

    public CornerRadius Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
