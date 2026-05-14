namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(char))]
#endif
public sealed class CharExtension : MarkupExtension
{
    public CharExtension(char value)
    {
        Value = value;
    }

    public char Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
