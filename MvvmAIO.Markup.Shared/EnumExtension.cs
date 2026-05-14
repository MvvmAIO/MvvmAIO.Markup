using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmAIO.Markup;

public class EnumExtension : MarkupExtension
{
    public EnumExtension(Type type, string str)
    {
        ArgumentNullException.ThrowIfNull(type, nameof(type));
        ArgumentNullException.ThrowIfNull(str, nameof(str));
        Value= Enum.Parse(type, str, true);
    }
    private object Value { get; }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Value;
    }
}
