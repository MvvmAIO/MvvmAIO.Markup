namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(double?))]
#endif
public sealed class NullableDoubleExtension : MarkupExtension
{
    public NullableDoubleExtension(double value) => Value = value;

    public NullableDoubleExtension() => Value = null;

    public double? Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value!;
}
