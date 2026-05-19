namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(char?))]
#endif
public sealed class NullableCharExtension : MarkupExtension
{
    public NullableCharExtension(char value) => Value = value;

    public NullableCharExtension() => Value = null;

    public char? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}
