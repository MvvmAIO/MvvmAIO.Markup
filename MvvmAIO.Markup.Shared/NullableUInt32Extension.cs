namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(uint?))]
#endif
public sealed class NullableUInt32Extension : MarkupExtension
{
    public NullableUInt32Extension(uint value) => Value = value;

    public NullableUInt32Extension() => Value = null;

    public uint? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}
