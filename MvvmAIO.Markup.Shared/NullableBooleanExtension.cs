namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(bool?))]
#endif
public sealed class NullableBooleanExtension : MarkupExtension
{
    public NullableBooleanExtension(bool value) => Value = value;

    public NullableBooleanExtension() => Value = null;

    public bool? Value { get; }

    public override object? ProvideValue(IServiceProvider serviceProvider) => Value;
}
