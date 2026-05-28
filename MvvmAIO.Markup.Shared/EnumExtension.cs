namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(Enum))]
#endif
public sealed class EnumExtension : MarkupExtension
{
    public EnumExtension(Type type, string str)
    {
        ArgumentNullException.ThrowIfNull(type);
        ArgumentNullException.ThrowIfNull(str);
        Value = Enum.Parse(type, str, ignoreCase: true);
    }

    public object Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
