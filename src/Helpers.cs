using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Labeleer;

internal static class Helpers {

    #region ToolStripBorderlessProfessionalRenderer

    private readonly static Lazy<ToolStripBorderlessProfessionalRenderer> _toolStripBorderlessSystemRendererInstance = new(
        () => new ToolStripBorderlessProfessionalRenderer());
    internal static ToolStripBorderlessProfessionalRenderer ToolStripBorderlessSystemRendererInstance => _toolStripBorderlessSystemRendererInstance.Value;

    internal class ToolStripBorderlessProfessionalRenderer : ToolStripProfessionalRenderer {

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }

    }

    #endregion

    #region Toolstrip images

    internal static void ScaleToolstrip(params ToolStrip[] toolstrips) {
        var sizeAndSet = GetSizeAndSet();
        var size = sizeAndSet.Key;
        var set = sizeAndSet.Value;

        var resources = Labeleer.Properties.Resources.ResourceManager;
        foreach (var toolstrip in toolstrips) {
            toolstrip.ImageScalingSize = new Size(size, size);
            foreach (ToolStripItem item in toolstrip.Items) {
                item.ImageScaling = ToolStripItemImageScaling.None;
                if (item.Image != null) { //update only those already having image
                    Bitmap? bitmap = null;
                    if (!string.IsNullOrEmpty(item.Name)) {
                        bitmap = resources.GetObject(item.Name + set) as Bitmap;
                    }
                    if ((bitmap == null) && !string.IsNullOrEmpty(item.Tag as string)) {
                        bitmap = resources.GetObject(item.Tag + set) as Bitmap;
                    }

                    item.ImageScaling = ToolStripItemImageScaling.None;
#if DEBUG
                    item.Image = (bitmap != null) ? new Bitmap(bitmap, size, size) : new Bitmap(size, size, PixelFormat.Format8bppIndexed);
#else
                        if (bitmap != null) { item.Image = new Bitmap(bitmap, size, size); }
#endif
                }

                if (item is ToolStripSplitButton toolstripSplitButton) { ScaleToolstrip(toolstripSplitButton.DropDown); }
            }
        }
    }

    internal static void ScaleToolstripItem(ToolStripItem item, string name) {
        var sizeAndSet = GetSizeAndSet();
        var size = sizeAndSet.Key;
        var set = sizeAndSet.Value;

        var resources = Labeleer.Properties.Resources.ResourceManager;
        item.ImageScaling = ToolStripItemImageScaling.None;
        if (resources.GetObject(name + set) is Bitmap bitmap) {
            item.Image = new Bitmap(bitmap, size, size);
        } else {
#if DEBUG
            item.Image = new Bitmap(size, size, PixelFormat.Format8bppIndexed);
#endif
        }
    }

    private static KeyValuePair<int, string> GetSizeAndSet() {
        return GetSizeAndSet(0.5);
    }

    private static KeyValuePair<int, string> GetSizeAndSet(double scaleBoost) {
        double scale;
        using (var control = new Control())
        using (var g = control.CreateGraphics()) {
            scale = Math.Max(Math.Max(g.DpiX, g.DpiY), 96.0) / 96.0;
        }

        scale += scaleBoost;

        if (scale < 1.5) {
            return new KeyValuePair<int, string>(16, "_16");
        } else if (scale < 2) {
            return new KeyValuePair<int, string>(24, "_24");
        } else if (scale < 3) {
            return new KeyValuePair<int, string>(32, "_32");
        } else {
            var base32 = 16 * scale / 32;
            var base48 = 16 * scale / 48;
            if ((base48 - (int)base48) < (base32 - (int)base32)) {
                return new KeyValuePair<int, string>(48 * (int)base48, "_48");
            } else {
                return new KeyValuePair<int, string>(32 * (int)base32, "_32");
            }
        }
    }

    #endregion

    #region Conversion

    public static int ToHundretsOfInches(float value) {
        return (int)((value * 100) / 25.4f);
    }

    public static float ToMillimeters(string? text) {
        if (text == null) { return 0; }
        text = text.Trim();

        float multiplier = 1;
        if (text.EndsWith("in")) {
            multiplier = 25.4f;
            text = text[0..^2];
        } else if (text.EndsWith("pt")) {
            multiplier = 25.4f / 72.0f;
            text = text[0..^2];
        } else if (text.EndsWith("mm")) {
            multiplier = 1;
            text = text[0..^2];
        } else if (text.EndsWith("cm")) {
            multiplier = 10;
            text = text[0..^2];
        }
        if (float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var result)) {
            return result * multiplier;
        } else {
            return 0;
        }
    }

    public static Color ToColor(string? text, Color? defaultColor = null) {
        if (text == null) { return defaultColor ?? Color.Transparent; }

        var props = typeof(Color).GetProperties(BindingFlags.Static
                                               | BindingFlags.DeclaredOnly
                                               | BindingFlags.Public);
        foreach (var prop in props) {
            if (prop.Name.Equals(text, StringComparison.InvariantCultureIgnoreCase)) {
                if (prop.GetValue(null) is Color color) {
                    return color;
                }
            }
        }

        return defaultColor ?? Color.Transparent;
    }

    public static ContentAlignment ToAlignment(string? text) {
        var horizontal = 0;
        var vertical = 0;

        if (text != null) {
            foreach (var part in text.Split('-')) {
                if (part.Equals("top", StringComparison.InvariantCulture)) {
                    vertical = -1;
                } else if (part.Equals("middle", StringComparison.InvariantCulture)) {
                    vertical = 0;
                } else if (part.Equals("bottom", StringComparison.InvariantCulture)) {
                    vertical = +1;
                } else if (part.Equals("left", StringComparison.InvariantCulture)) {
                    horizontal = -1;
                } else if (part.Equals("center", StringComparison.InvariantCulture)) {
                    horizontal = 0;
                } else if (part.Equals("right", StringComparison.InvariantCulture)) {
                    horizontal = +1;
                }
            }
        }

        if ((vertical == 0) && (horizontal == -1)) {
            return ContentAlignment.MiddleLeft;
        } else if ((vertical == 0) && (horizontal == +1)) {
            return ContentAlignment.MiddleRight;
        } else if ((vertical == -1) && (horizontal == -1)) {
            return ContentAlignment.TopLeft;
        } else if ((vertical == -1) && (horizontal == 0)) {
            return ContentAlignment.TopCenter;
        } else if ((vertical == -1) && (horizontal == +1)) {
            return ContentAlignment.TopRight;
        } else if ((vertical == +1) && (horizontal == -1)) {
            return ContentAlignment.BottomLeft;
        } else if ((vertical == +1) && (horizontal == 0)) {
            return ContentAlignment.BottomCenter;
        } else if ((vertical == +1) && (horizontal == +1)) {
            return ContentAlignment.BottomRight;
        } else {
            return ContentAlignment.MiddleCenter;
        }
    }

    #endregion Conversion

    public static PrinterResolution GetHighest(PrinterSettings.PrinterResolutionCollection printerResolutions) {
        foreach (PrinterResolution resolution in printerResolutions) {
            if (resolution.Kind == PrinterResolutionKind.High) {
                return resolution;
            }
        }
        return printerResolutions[0];
    }

}
