using System.Drawing;
using Medo.Configuration;
using Medo.Text;
using static Labeleer.Helpers;

namespace Labeleer;

internal sealed record TextBlock : BaseBlock {

    public TextBlock(float left, float top,
                     float width, float height,
                     string text,
                     Font font, Color fontColor,
                     ContentAlignment alignment)
                     : base(left, top, width, height) {

        Text = text;

        Font = font;
        FontColor = fontColor;

        Alignment = alignment;
    }

    public string Text { get; init; }

    public Font Font { get; init; }
    public Color FontColor { get; init; }

    public ContentAlignment Alignment { get; init; }


    public override void Draw(Graphics graphics, RectangleF labelRectangle, ParameterExpansion expansion) {
        var rect = ToAbsoluteRectangle(labelRectangle);
        graphics.SetClip(rect);

        StringFormat format = StringFormat.GenericTypographic;
        if (Alignment == ContentAlignment.TopLeft) {
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Near;
        } else if (Alignment == ContentAlignment.TopCenter) {
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Center;
        } else if (Alignment == ContentAlignment.TopRight) {
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Far;
        } else if (Alignment == ContentAlignment.MiddleLeft) {
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Near;
        } else if (Alignment == ContentAlignment.MiddleCenter) {
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
        } else if (Alignment == ContentAlignment.MiddleRight) {
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Far;
        } else if (Alignment == ContentAlignment.BottomLeft) {
            format.LineAlignment = StringAlignment.Far;
            format.Alignment = StringAlignment.Near;
        } else if (Alignment == ContentAlignment.BottomCenter) {
            format.LineAlignment = StringAlignment.Far;
            format.Alignment = StringAlignment.Center;
        } else if (Alignment == ContentAlignment.BottomRight) {
            format.LineAlignment = StringAlignment.Far;
            format.Alignment = StringAlignment.Far;
        } else {
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
        }

        using var brush = new SolidBrush(FontColor);
        graphics.DrawString(expansion.Expand(Text), Font, brush, rect, format);
    }



    #region Static

    internal static BaseBlock FromIniSection(IniFile ini, string section) {
        var left = ToMillimeters(ini.Read(section, "Left"));
        var top = ToMillimeters(ini.Read(section, "Top"));
        var width = ToMillimeters(ini.Read(section, "Width"));
        var height = ToMillimeters(ini.Read(section, "Height"));

        var text = ini.Read(section, "Text", "");

        var fontName = ini.Read(section, "FontName", "");
        var fontSize = ToMillimeters(ini.Read(section, "FontSize"));
        var fontColor = ToColor(ini.Read(section, "FontColor"), Color.Black);
        var font = new Font(fontName, fontSize, GraphicsUnit.Millimeter);

        var alignment = ToAlignment(ini.Read(section, "Alignment"));

        return new TextBlock(left, top, width, height, text, font, fontColor, alignment);
    }

    #endregion Static

}
