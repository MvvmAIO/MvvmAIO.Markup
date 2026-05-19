namespace MvvmAIO.Markup;

public sealed class NullableVectorExtension : MarkupExtension
{
    public NullableVectorExtension(string value) => Value = MarkupValueParser.FromString<Vector>(value);

    public NullableVectorExtension() => Value = null;

    public Vector? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}