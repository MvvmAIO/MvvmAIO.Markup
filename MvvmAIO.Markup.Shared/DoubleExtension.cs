namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(double))]
#endif
public sealed class DoubleExtension : MarkupExtension
{
    public DoubleExtension(double value)
    {
        Value = value;
    }

    public double Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
