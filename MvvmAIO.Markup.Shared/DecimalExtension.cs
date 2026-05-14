namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(decimal))]
#endif
public sealed class DecimalExtension : MarkupExtension
{
    public DecimalExtension(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
