namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(System.Guid?))]
#endif
public sealed class NullableGuidExtension : MarkupExtension
{
    public NullableGuidExtension(System.Guid value) => Value = value;

    public NullableGuidExtension() => Value = null;

    public System.Guid? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}
