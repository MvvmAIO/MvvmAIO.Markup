using System.Globalization;
using System.Windows;

namespace MvvmAIO.Markup.Tests;

public sealed class SharedExtensionsTests
{
    [Fact]
    public void Int32Extension_ProvideValue_ReturnsValue() =>
        Assert.Equal(42, MarkupExtensionTestHelper.ProvideValue(new Int32Extension(42)));

    [Fact]
    public void TrueExtension_ProvideValue_ReturnsTrue() =>
        Assert.Equal(true, MarkupExtensionTestHelper.ProvideValue(new TrueExtension()));

    [Fact]
    public void FalseExtension_ProvideValue_ReturnsFalse() =>
        Assert.Equal(false, MarkupExtensionTestHelper.ProvideValue(new FalseExtension()));

    [Fact]
    public void BooleanExtension_ProvideValue_ReturnsValue() =>
        Assert.Equal(true, MarkupExtensionTestHelper.ProvideValue(new BooleanExtension(true)));

    [Fact]
    public void StringExtension_ProvideValue_ReturnsValue() =>
        Assert.Equal("Save", MarkupExtensionTestHelper.ProvideValue(new StringExtension("Save")));

    [Fact]
    public void UriExtension_ProvideValue_ReturnsAbsoluteUri()
    {
        var uri = (Uri)MarkupExtensionTestHelper.ProvideValue(new UriExtension("https://example.com/path"));
        Assert.Equal("https://example.com/path", uri.AbsoluteUri);
    }

    [Fact]
    public void CultureInfoExtension_ProvideValue_ReturnsCulture() =>
        Assert.Equal("zh-CN", ((CultureInfo)MarkupExtensionTestHelper.ProvideValue(new CultureInfoExtension("zh-CN"))).Name);

    [Fact]
    public void EnumExtension_ProvideValue_ParsesIgnoreCase()
    {
        var value = MarkupExtensionTestHelper.ProvideValue(new EnumExtension(typeof(TextAlignment), "ceNter"));
        Assert.Equal(TextAlignment.Center, value);
    }

    [Fact]
    public void EnumExtension_ProvideValue_ParsesNumericValue()
    {
        var value = MarkupExtensionTestHelper.ProvideValue(new EnumExtension(typeof(TextAlignment), "2"));
        Assert.Equal(TextAlignment.Center, value);
    }

    [Fact]
    public void EnumExtension_InvalidMember_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            MarkupExtensionTestHelper.ProvideValue(new EnumExtension(typeof(TextAlignment), "NotARealMember")));
    }
}
