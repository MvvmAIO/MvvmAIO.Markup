namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(System.DateTime?))]
#endif
public sealed class NullableDateTimeExtension : MarkupExtension
{
    public NullableDateTimeExtension(System.DateTime value) => Value = value;

    public NullableDateTimeExtension() => Value = null;

    public System.DateTime? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}
