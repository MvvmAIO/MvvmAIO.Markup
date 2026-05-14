namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(System.TimeSpan))]
#endif
public sealed class TimeSpanExtension : MarkupExtension
{
    public TimeSpanExtension(System.TimeSpan value)
    {
        Value = value;
    }

    public System.TimeSpan Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
