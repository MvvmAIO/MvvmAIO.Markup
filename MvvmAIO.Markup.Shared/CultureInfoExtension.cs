using System.Globalization;

namespace MvvmAIO.Markup;

#if WPF
[System.Windows.Markup.MarkupExtensionReturnType(typeof(CultureInfo))]
#endif
public sealed class CultureInfoExtension : MarkupExtension
{
    public CultureInfoExtension(string name) => Value = CultureInfo.GetCultureInfo(name);

    public CultureInfo Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider) => Value;
}
