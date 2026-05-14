namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(short))]
#endif
public sealed class Int16Extension : MarkupExtension
{
    public Int16Extension(short value)
    {
        Value = value;
    }

    public short Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
