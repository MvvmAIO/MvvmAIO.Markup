namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(byte))]
#endif
public sealed class ByteExtension : MarkupExtension
{
    public ByteExtension(byte value)
    {
        Value = value;
    }

    public byte Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
