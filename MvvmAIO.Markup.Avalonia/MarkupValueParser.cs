using System.Globalization;

namespace MvvmAIO.Markup;

internal static class MarkupValueParser
{
    public static T FromString<T>(string value) =>
        typeof(T) switch
        {
            Type t when t == typeof(Thickness) => (T)(object)Thickness.Parse(value),
            Type t when t == typeof(Point) => (T)(object)Point.Parse(value),
            Type t when t == typeof(Size) => (T)(object)Size.Parse(value),
            Type t when t == typeof(Rect) => (T)(object)Rect.Parse(value),
            Type t when t == typeof(Vector) => (T)(object)Vector.Parse(value),
            Type t when t == typeof(GridLength) => (T)(object)GridLength.Parse(value),
            Type t when t == typeof(CornerRadius) => (T)(object)CornerRadius.Parse(value),
            _ => FromStringViaTypeConverter<T>(value),
        };

    static T FromStringViaTypeConverter<T>(string value)
    {
        var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
        var result = converter.ConvertFrom(null, CultureInfo.InvariantCulture, value)
            ?? throw new FormatException($"Could not convert '{value}' to {typeof(T).Name}.");

        return (T)result;
    }
}
