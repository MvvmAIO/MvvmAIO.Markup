namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(ulong))]
#endif
public sealed class UInt64Extension : MarkupExtension
{
    public UInt64Extension(ulong value)
    {
        Value = value;
    }

    public ulong Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
