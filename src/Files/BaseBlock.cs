using System.Drawing;
using Medo.Text;

namespace Labeleer;

public abstract record BaseBlock {

    public BaseBlock(float left, float top, float width, float height) {
        Left = left;
        Top = top;
        Width = width;
        Height = height;
    }

    public float Left { get; init; }
    public float Top { get; init; }
    public float Width { get; init; }
    public float Height { get; init; }

    public RectangleF Rectangle { get { return new RectangleF(Left, Top, Width, Height); } }

    public abstract void Draw(Graphics graphics, RectangleF labelRectangle, ParameterExpansion expansion);

    public RectangleF ToAbsoluteRectangle(RectangleF referenceRectangle) {
        return new RectangleF(referenceRectangle.Left + Left,
                              referenceRectangle.Top + Top,
                              Width, Height);
    }

}
