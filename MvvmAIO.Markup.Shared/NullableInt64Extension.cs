namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(long?))]
#endif
public sealed class NullableInt64Extension : MarkupExtension
{
    public NullableInt64Extension(long value) => Value = value;

    public NullableInt64Extension() => Value = null;

    public long? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}
