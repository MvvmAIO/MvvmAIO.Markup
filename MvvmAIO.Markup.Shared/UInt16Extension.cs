namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(ushort))]
#endif
public sealed class UInt16Extension : MarkupExtension
{
    public UInt16Extension(ushort value)
    {
        Value = value;
    }

    public ushort Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
