using PdfSharp.Fonts;

public class NotoFontResolver : IFontResolver
{
    public byte[]? GetFont(string faceName)
    {
        return faceName switch
        {
            "NotoSansSC-Bold" => PDFSharpDemo.Properties.Resources.NotoSansSC_Bold,
            _ => PDFSharpDemo.Properties.Resources.NotoSansSC_Regular,
        };
    }

    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        if (familyName == "NotoSansSC")
        {
            return new FontResolverInfo($"NotoSansSC-{(bold ? "Bold" : "Regular")}");
        }
        return null;
    }
}