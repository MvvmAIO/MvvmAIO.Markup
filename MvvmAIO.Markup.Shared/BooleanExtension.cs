namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(bool))]
#endif
public sealed class BooleanExtension : MarkupExtension
{
    public BooleanExtension(bool value)
    {
        Value = value;
    }

    public bool Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
