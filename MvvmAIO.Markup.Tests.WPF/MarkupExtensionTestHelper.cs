namespace MvvmAIO.Markup.Tests;

internal static class MarkupExtensionTestHelper
{
    public static object ProvideValue(MarkupExtension extension) =>
        extension.ProvideValue(serviceProvider: null!);
}
