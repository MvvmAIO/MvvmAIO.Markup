using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MvvmAIO.Markup.Tests;

public sealed class WpfMediaExtensionsTests
{
    [Fact]
    public void ColorExtension_ParseHex() =>
        Assert.Equal(Colors.Red, (Color)MarkupExtensionTestHelper.ProvideValue(new ColorExtension("#FFFF0000")));

    [Fact]
    public void DurationExtension_ParseTimeSpan() =>
        Assert.Equal(new Duration(TimeSpan.FromSeconds(5)), (Duration)MarkupExtensionTestHelper.ProvideValue(new DurationExtension("0:0:5")));

    [Fact]
    public void KeyTimeExtension_ParseTimeSpan() =>
        Assert.Equal(KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)), (KeyTime)MarkupExtensionTestHelper.ProvideValue(new KeyTimeExtension("0:0:2")));
}
