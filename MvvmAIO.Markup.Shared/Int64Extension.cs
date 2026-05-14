namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(long))]
#endif
public sealed class Int64Extension : MarkupExtension
{
    public Int64Extension(long value)
    {
        Value = value;
    }

    public long Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
