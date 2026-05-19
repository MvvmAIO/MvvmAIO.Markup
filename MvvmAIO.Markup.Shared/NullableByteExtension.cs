namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(byte?))]
#endif
public sealed class NullableByteExtension : MarkupExtension
{
    public NullableByteExtension(byte value) => Value = value;

    public NullableByteExtension() => Value = null;

    public byte? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}
