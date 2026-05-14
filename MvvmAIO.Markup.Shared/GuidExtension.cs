namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(System.Guid))]
#endif
public sealed class GuidExtension : MarkupExtension
{
    public GuidExtension(System.Guid value)
    {
        Value = value;
    }

    public System.Guid Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
