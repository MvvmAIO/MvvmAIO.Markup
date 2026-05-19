namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(ushort?))]
#endif
public sealed class NullableUInt16Extension : MarkupExtension
{
    public NullableUInt16Extension(ushort value) => Value = value;

    public NullableUInt16Extension() => Value = null;

    public ushort? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}
