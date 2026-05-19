namespace MvvmAIO.Markup;

public sealed class NullableGridLengthExtension : MarkupExtension
{
    public NullableGridLengthExtension(string value) => Value = MarkupValueParser.FromString<GridLength>(value);

    public NullableGridLengthExtension() => Value = null;

    public GridLength? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}