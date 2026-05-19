namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(bool))]
#endif
public sealed class FalseExtension : MarkupExtension
{
    public override object ProvideValue(IServiceProvider serviceProvider) => false;
}
