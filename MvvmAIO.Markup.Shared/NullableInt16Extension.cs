namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(short?))]
#endif
public sealed class NullableInt16Extension : MarkupExtension
{
    public NullableInt16Extension(short value) => Value = value;

    public NullableInt16Extension() => Value = null;

    public short? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}
