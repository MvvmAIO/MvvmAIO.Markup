namespace MvvmAIO.Markup;

[MarkupExtensionReturnType(typeof(GridLength))]
public sealed class GridLengthExtension : MarkupExtension
{
    public GridLengthExtension(string value) => Value = MarkupValueParser.FromString<GridLength>(value);

    public GridLength Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
