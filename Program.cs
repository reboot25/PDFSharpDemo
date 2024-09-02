using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;

GlobalFontSettings.FallbackFontResolver = new NotoFontResolver();

// Create a new PDF document.
var document = new PdfDocument();
document.Info.Title = "Created with PDFsharp";
document.Info.Subject = "Just a simple Hello-World program.";

// Create an empty page in this document.
var page = document.AddPage();
//page.Size = PageSize.Letter;

// Get an XGraphics object for drawing on this page.
var gfx = XGraphics.FromPdfPage(page);

// Draw two lines with a red default pen.
var width = page.Width.Point;
var height = page.Height.Point;
gfx.DrawLine(XPens.Red, 0, 0, width, height);
gfx.DrawLine(XPens.Red, width, 0, 0, height);

// Draw a circle with a red pen which is 1.5 point thick.
var r = width / 5;
gfx.DrawEllipse(new XPen(XColors.Red, 1.5), XBrushes.White, new XRect(width / 2 - r, height / 2 - r, 2 * r, 2 * r));

// Create a font.
var font = new XFont("NotoSansSC", 20, XFontStyleEx.Regular);
var fontbd = new XFont("NotoSansSC", 20, XFontStyleEx.Bold);
var fonttn = new XFont("Times New Roman", 20, XFontStyleEx.Regular);

// Draw the text.
gfx.DrawString("你好，PDFSharp!", font, XBrushes.Black, new XRect(0, -32, page.Width.Point, page.Height.Point), XStringFormats.Center);

gfx.DrawString("你好，PDFSharp!", fontbd, XBrushes.Black, new XRect(0, 0, page.Width.Point, page.Height.Point), XStringFormats.Center);

gfx.DrawString("Hello, PDFSharp!", fonttn, XBrushes.Black, new XRect(0, 32, page.Width.Point, page.Height.Point), XStringFormats.Center);

// Save the document...
var filename = PdfFileUtility.GetTempPdfFullFileName("samples/HelloWorldSample");
document.Save(filename);
// ...and start a viewer.
PdfFileUtility.ShowDocument(filename);