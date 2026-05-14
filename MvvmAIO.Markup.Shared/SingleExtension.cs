namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(float))]
#endif
public sealed class SingleExtension : MarkupExtension
{
    public SingleExtension(float value)
    {
        Value = value;
    }

    public float Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
