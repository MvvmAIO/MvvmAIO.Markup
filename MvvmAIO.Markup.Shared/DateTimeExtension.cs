namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(System.DateTime))]
#endif
public sealed class DateTimeExtension : MarkupExtension
{
    public DateTimeExtension(System.DateTime value)
    {
        Value = value;
    }

    public System.DateTime Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
