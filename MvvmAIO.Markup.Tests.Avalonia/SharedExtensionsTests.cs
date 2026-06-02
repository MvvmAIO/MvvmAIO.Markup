using System.Globalization;

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
    public void GuidExtension_ProvideValue_ReturnsValue()
    {
        var expected = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890");
        Assert.Equal(expected, MarkupExtensionTestHelper.ProvideValue(new GuidExtension(expected)));
    }

    [Fact]
    public void DateTimeExtension_ProvideValue_ReturnsValue()
    {
        var expected = new DateTime(2026, 6, 2, 12, 30, 0, DateTimeKind.Utc);
        Assert.Equal(expected, MarkupExtensionTestHelper.ProvideValue(new DateTimeExtension(expected)));
    }

    [Fact]
    public void TimeSpanExtension_ProvideValue_ReturnsValue() =>
        Assert.Equal(TimeSpan.FromMinutes(5), MarkupExtensionTestHelper.ProvideValue(new TimeSpanExtension(TimeSpan.FromMinutes(5))));

    [Fact]
    public void DecimalExtension_ProvideValue_ReturnsValue() =>
        Assert.Equal(12.34m, MarkupExtensionTestHelper.ProvideValue(new DecimalExtension(12.34m)));

    [Fact]
    public void EnumExtension_ProvideValue_ParsesIgnoreCase()
    {
        var value = MarkupExtensionTestHelper.ProvideValue(new EnumExtension(typeof(TextAlignment), "ceNter"));
        Assert.Equal(TextAlignment.Center, value);
    }

    [Fact]
    public void EnumExtension_ProvideValue_ParsesNumericValue()
    {
        var numeric = ((int)TextAlignment.Center).ToString();
        var value = MarkupExtensionTestHelper.ProvideValue(new EnumExtension(typeof(TextAlignment), numeric));
        Assert.Equal(TextAlignment.Center, value);
    }

    [Fact]
    public void EnumExtension_InvalidMember_Throws()
    {
        Assert.Throws<ArgumentException>(() =>
            MarkupExtensionTestHelper.ProvideValue(new EnumExtension(typeof(TextAlignment), "NotARealMember")));
    }
}
