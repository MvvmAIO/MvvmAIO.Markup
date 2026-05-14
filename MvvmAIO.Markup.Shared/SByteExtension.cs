namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(sbyte))]
#endif
public sealed class SByteExtension : MarkupExtension
{
    public SByteExtension(sbyte value)
    {
        Value = value;
    }

    public sbyte Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
