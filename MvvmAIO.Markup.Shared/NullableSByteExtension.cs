namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(sbyte?))]
#endif
public sealed class NullableSByteExtension : MarkupExtension
{
    public NullableSByteExtension(sbyte value) => Value = value;

    public NullableSByteExtension() => Value = null;

    public sbyte? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}
