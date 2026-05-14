namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(int))]
#endif
public sealed class Int32Extension : MarkupExtension
{
    public Int32Extension(int value)
    {
        Value = value;
    }

    public int Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
