namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(uint))]
#endif
public sealed class UInt32Extension : MarkupExtension
{
    public UInt32Extension(uint value)
    {
        Value = value;
    }

    public uint Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
