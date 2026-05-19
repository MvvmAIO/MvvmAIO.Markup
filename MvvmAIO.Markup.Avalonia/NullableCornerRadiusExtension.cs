namespace MvvmAIO.Markup;

public sealed class NullableCornerRadiusExtension : MarkupExtension
{
    public NullableCornerRadiusExtension(string value) => Value = MarkupValueParser.FromString<CornerRadius>(value);

    public NullableCornerRadiusExtension() => Value = null;

    public CornerRadius? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}