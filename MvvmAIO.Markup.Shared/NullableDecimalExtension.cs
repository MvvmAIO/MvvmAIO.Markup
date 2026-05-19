namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(decimal?))]
#endif
public sealed class NullableDecimalExtension : MarkupExtension
{
    public NullableDecimalExtension(decimal value) => Value = value;

    public NullableDecimalExtension() => Value = null;

    public decimal? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}
