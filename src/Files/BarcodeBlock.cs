using System.Drawing;
using Medo.Configuration;
using Medo.Drawing;
using Medo.Text;
using static Labeleer.Helpers;

namespace Labeleer;

public sealed record BarcodeBlock : BaseBlock {

    public BarcodeBlock(float left, float top,
                     float width, float height,
                     string value,
                     ContentAlignment alignment,
                     float barWidth)
                     : base(left, top, width, height) {

        Value = value;
        Alignment = alignment;
        BarWidth = barWidth;
    }

    public string Value { get; init; }
    public ContentAlignment Alignment { get; init; }
    public float BarWidth { get; init; }


    public override void Draw(Graphics graphics, RectangleF labelRectangle, ParameterExpansion expansion) {
        var rect = ToAbsoluteRectangle(labelRectangle);
        graphics.SetClip(rect);

        var barcode = BarcodePattern.GetNewCode128(expansion.Expand(Value));
        var barcodeWidth = barcode.GetPatternWidth();

        var width = barcodeWidth * BarWidth;
        var left = Alignment switch {
            ContentAlignment.TopLeft or ContentAlignment.MiddleLeft or ContentAlignment.BottomLeft => rect.Left,
            ContentAlignment.TopRight or ContentAlignment.MiddleRight or ContentAlignment.BottomRight => rect.Right - width,
            _ => rect.Left + (rect.Width - width) / 2,
        };
        var isBar = true;
        foreach (var amount in barcode.GetInterleavedPattern()) {
            var multiplier = (amount == 0) ? 1 : amount;
            if (isBar) {
                graphics.FillRectangle(Brushes.Black, left, rect.Top, BarWidth * multiplier, rect.Height);
            } else {
                graphics.FillRectangle(Brushes.White, left, rect.Top, BarWidth * multiplier, rect.Height);
            }
            left += BarWidth * multiplier;
            isBar = !isBar;
        }
    }


    #region Static

    internal static BaseBlock FromIniSection(IniFile ini, string section) {
        var left = ToMillimeters(ini.Read(section, "Left"));
        var top = ToMillimeters(ini.Read(section, "Top"));
        var width = ToMillimeters(ini.Read(section, "Width"));
        var height = ToMillimeters(ini.Read(section, "Height"));

        var value = ini.Read(section, "Value", "");
        var alignment = ToAlignment(ini.Read(section, "Alignment"));
        var barWidth = ToMillimeters(ini.Read(section, "BarWidth"));

        return new BarcodeBlock(left, top, width, height, value, alignment, barWidth);
    }

    #endregion Static

}
