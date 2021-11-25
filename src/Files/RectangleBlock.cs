using System.Drawing;
using Medo.Configuration;
using Medo.Text;
using static Labeleer.Helpers;

namespace Labeleer;

public sealed record RectangleBlock : BaseBlock {

    public RectangleBlock(float left, float top,
                          float width, float height,
                          Color borderColor, float borderSize,
                          Color fillColor)
                          : base(left, top, width, height) {

        BorderColor = borderColor;
        BorderSize = borderSize;

        FillColor = fillColor;
    }

    public Color BorderColor { get; init; }
    public float BorderSize { get; init; }

    public Color FillColor { get; init; }


    public override void Draw(Graphics graphics, RectangleF labelRectangle, ParameterExpansion expansion) {
        var rect = ToAbsoluteRectangle(labelRectangle);

        if (FillColor.A > 0) {
            using var brush = new SolidBrush(FillColor);
            graphics.FillRectangle(brush, rect);
        }

        if (BorderColor.A > 0) {
            using var pen = new Pen(BorderColor, BorderSize);
            graphics.DrawRectangle(pen, rect.Left, rect.Top, rect.Width, rect.Height);
        }
    }


    #region Static

    internal static BaseBlock FromIniSection(IniFile ini, string section) {
        var left = ToMillimeters(ini.Read(section, "Left"));
        var top = ToMillimeters(ini.Read(section, "Top"));
        var width = ToMillimeters(ini.Read(section, "Width"));
        var height = ToMillimeters(ini.Read(section, "Height"));

        var borderColor = ToColor(ini.Read(section, "BorderColor"));
        var borderSize = ToMillimeters(ini.Read(section, "BorderSize"));

        var fillColor = ToColor(ini.Read(section, "FillColor"));

        return new RectangleBlock(left, top, width, height, borderColor, borderSize, fillColor);
    }

    #endregion Static

}
