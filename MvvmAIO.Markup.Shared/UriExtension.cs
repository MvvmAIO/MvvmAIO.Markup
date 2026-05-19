namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(Uri))]
#endif
public sealed class UriExtension : MarkupExtension
{
    public UriExtension(string value) => Value = new Uri(value, UriKind.RelativeOrAbsolute);

    public Uri Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
