namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(float?))]
#endif
public sealed class NullableSingleExtension : MarkupExtension
{
    public NullableSingleExtension(float value) => Value = value;

    public NullableSingleExtension() => Value = null;

    public float? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}
