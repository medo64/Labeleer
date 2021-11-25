using Medo.Configuration;
using static Labeleer.Helpers;

namespace Labeleer;

public sealed record Paper {

    public Paper(string name,
                 float paperWidth, float paperHeight,
                 float labelWidth, float labelHeight,
                 float labelOffsetY, float labelOffsetX,
                 float labelSpacingX, float labelSpacingY,
                 int labelCountX, int labelCountY) {

        Name = name;

        PaperWidth = paperWidth;
        PaperHeight = paperHeight;

        LabelWidth = labelWidth;
        LabelHeight = labelHeight;

        LabelOffsetY = labelOffsetX;
        LabelOffsetX = labelOffsetY;
        LabelSpacingX = labelSpacingX;
        LabelSpacingY = labelSpacingY;

        LabelCountX = labelCountX;
        LabelCountY = labelCountY;
    }


    public string Name { get; init; }

    public float PaperWidth { get; init; }
    public float PaperHeight { get; init; }

    public float LabelWidth { get; init; }
    public float LabelHeight { get; init; }

    public float LabelOffsetX { get; init; }
    public float LabelOffsetY { get; init; }

    public float LabelSpacingX { get; init; }
    public float LabelSpacingY { get; init; }

    public int LabelCountX { get; init; }
    public int LabelCountY { get; init; }


    #region Static

    internal static Paper FromIniSection(IniFile ini, string section) {
        var name = ini.Read(section, "Name", section);
        var paperWidth = ToMillimeters(ini.Read(section, "PaperWidth"));
        var paperHeight = ToMillimeters(ini.Read(section, "PaperHeight"));
        var labelWidth = ToMillimeters(ini.Read(section, "LabelWidth"));
        var labelHeight = ToMillimeters(ini.Read(section, "LabelHeight"));
        var labelLeftOffset = ToMillimeters(ini.Read(section, "LabelOffsetX"));
        var labelTopOffset = ToMillimeters(ini.Read(section, "LabelOffsetY"));
        var labelHorizontalSpacing = ToMillimeters(ini.Read(section, "LabelSpacingX"));
        var labelVerticalSpacing = ToMillimeters(ini.Read(section, "LabelSpacingY"));
        var labelHorizontalCount = ini.Read(section, "LabelCountX", 0);
        var labelVerticalCount = ini.Read(section, "LabelCountY", 0);
        return new Paper(name,
            paperWidth, paperHeight,
            labelWidth, labelHeight,
            labelLeftOffset, labelTopOffset,
            labelHorizontalSpacing, labelVerticalSpacing,
            labelHorizontalCount, labelVerticalCount);
    }

    #endregion Static

}
