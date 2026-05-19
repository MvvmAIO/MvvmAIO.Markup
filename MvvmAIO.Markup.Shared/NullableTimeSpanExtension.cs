namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(System.TimeSpan?))]
#endif
public sealed class NullableTimeSpanExtension : MarkupExtension
{
    public NullableTimeSpanExtension(System.TimeSpan value) => Value = value;

    public NullableTimeSpanExtension() => Value = null;

    public System.TimeSpan? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}
