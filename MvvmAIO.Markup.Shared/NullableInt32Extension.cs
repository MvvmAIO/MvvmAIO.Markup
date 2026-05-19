namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(int?))]
#endif
public sealed class NullableInt32Extension : MarkupExtension
{
    public NullableInt32Extension(int value) => Value = value;

    public NullableInt32Extension() => Value = null;

    public int? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}
