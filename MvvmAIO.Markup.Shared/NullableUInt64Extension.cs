namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(ulong?))]
#endif
public sealed class NullableUInt64Extension : MarkupExtension
{
    public NullableUInt64Extension(ulong value) => Value = value;

    public NullableUInt64Extension() => Value = null;

    public ulong? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}
