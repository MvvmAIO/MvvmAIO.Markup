namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(string))]
#endif
public sealed class StringExtension : MarkupExtension
{
    public StringExtension(string value) => Value = value;

    public string Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
