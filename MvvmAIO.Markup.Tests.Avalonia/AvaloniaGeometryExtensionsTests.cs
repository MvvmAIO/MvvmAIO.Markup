namespace MvvmAIO.Markup.Tests;

public sealed class AvaloniaGeometryExtensionsTests
{
    [Fact]
    public void ThicknessExtension_Uniform() =>
        Assert.Equal(new Thickness(8), (Thickness)MarkupExtensionTestHelper.ProvideValue(new ThicknessExtension("8")));

    [Fact]
    public void PointExtension_Parse() =>
        Assert.Equal(new Point(10, 20), (Point)MarkupExtensionTestHelper.ProvideValue(new PointExtension("10,20")));

    [Fact]
    public void SizeExtension_Parse() =>
        Assert.Equal(new Size(100, 50), (Size)MarkupExtensionTestHelper.ProvideValue(new SizeExtension("100,50")));

    [Fact]
    public void RectExtension_Parse() =>
        Assert.Equal(new Rect(0, 0, 100, 50), (Rect)MarkupExtensionTestHelper.ProvideValue(new RectExtension("0,0,100,50")));

    [Fact]
    public void VectorExtension_Parse() =>
        Assert.Equal(new Vector(1, 0), (Vector)MarkupExtensionTestHelper.ProvideValue(new VectorExtension("1,0")));

    [Fact]
    public void GridLengthExtension_Auto() =>
        Assert.Equal(GridLength.Auto, (GridLength)MarkupExtensionTestHelper.ProvideValue(new GridLengthExtension("Auto")));

    [Fact]
    public void CornerRadiusExtension_Uniform() =>
        Assert.Equal(new CornerRadius(4), (CornerRadius)MarkupExtensionTestHelper.ProvideValue(new CornerRadiusExtension("4")));

    [Fact]
    public void ColorExtension_ParseHex() =>
        Assert.Equal(Colors.Red, (Color)MarkupExtensionTestHelper.ProvideValue(new ColorExtension("#FFFF0000")));
}
