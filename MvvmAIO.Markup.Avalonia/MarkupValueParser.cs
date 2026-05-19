using System.ComponentModel;
using System.Globalization;

namespace MvvmAIO.Markup;

internal static class MarkupValueParser
{
    public static T FromString<T>(string value)
    {
        var converter = TypeDescriptor.GetConverter(typeof(T));
        var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, value)
            ?? throw new FormatException($"Could not convert '{value}' to {typeof(T).Name}.");

        return (T)result;
    }
}
