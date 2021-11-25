using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Text;
using Medo.Configuration;
using Medo.Text;
using static Labeleer.Helpers;

namespace Labeleer;

public class Document {

    public Document(string path) {
        var iniFile = new IniFile(path);

        Paper = Paper.FromIniSection(iniFile, "Paper");

        OffsetX = ToMillimeters(iniFile.Read("Paper", "OffsetX"));
        OffsetY = ToMillimeters(iniFile.Read("Paper", "OffsetY"));

        var blocks = new List<BaseBlock>();
        var variables = new List<Variable>();
        foreach (var section in iniFile.GetSections()) {
            if (section.StartsWith("Variable", StringComparison.CurrentCultureIgnoreCase)) {
                variables.Add(Variable.FromIniSection(iniFile, section));
            } else if (section.StartsWith("RectangleBlock", StringComparison.CurrentCultureIgnoreCase)) {
                blocks.Add(RectangleBlock.FromIniSection(iniFile, section));
            } else if (section.StartsWith("TextBlock", StringComparison.CurrentCultureIgnoreCase)) {
                blocks.Add(TextBlock.FromIniSection(iniFile, section));
            } else if (section.StartsWith("BarcodeBlock", StringComparison.CurrentCultureIgnoreCase)) {
                blocks.Add(BarcodeBlock.FromIniSection(iniFile, section));
            }
        }
        Blocks = blocks;
        Variables = variables;
    }

    public Paper Paper { get; private set; }
    public List<BaseBlock> Blocks { get; private set; }
    public List<Variable> Variables { get; private set; }

    public float OffsetX { get; init; }
    public float OffsetY { get; init; }

    public void Draw(Graphics graphics) {
        var expansion = new ParameterExpansion();
        expansion.RetrieveParameter += delegate (object? sender, ParameterExpansionEventArgs e) {
            foreach (var variable in Variables) {
                if (e.Name.Equals(variable.Name, StringComparison.InvariantCultureIgnoreCase)) {
                    e.Value = variable.Value;
                    break;
                }
            }
        };

        graphics.PageUnit = GraphicsUnit.Millimeter;
        graphics.CompositingQuality = CompositingQuality.AssumeLinear;
        graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        graphics.SmoothingMode = SmoothingMode.None;

        for (var y = 0; y < Paper.LabelCountY; y++) {
            for (var x = 0; x < Paper.LabelCountX; x++) {
                var width = Paper.LabelWidth;
                var height = Paper.LabelHeight;
                var left = OffsetX + Paper.LabelOffsetX + x * (Paper.LabelSpacingX + width);
                var top = OffsetY + Paper.LabelOffsetY + y * (Paper.LabelSpacingY + height);
                var rect = new RectangleF((float)left, (float)top, (float)width, (float)height);

                var horizontalBleed = Paper.LabelSpacingX / 2;
                var verticalBleed = Paper.LabelSpacingY / 2;
                var bleedRect = new RectangleF((float)(left - horizontalBleed),
                                               (float)(top - verticalBleed),
                                               (float)(width + horizontalBleed * 2),
                                               (float)(height + verticalBleed * 2));

                foreach (var block in Blocks) {
                    graphics.SetClip(bleedRect);  // allow a bit of bleed, but not too much
                    block.Draw(graphics, rect, expansion);
                }

                foreach (var variable in Variables) {
                    variable.IncrementIfNeeded();
                }
            }
        }
    }

}
