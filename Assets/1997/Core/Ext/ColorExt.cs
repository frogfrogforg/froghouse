using UnityEngine;

namespace Frog1997 {

/// unity color extensions
public static class ColorExt {
    // -- operators --
    /// creates a new color with the alpha
    public static Color A(this Color c, float a) {
        c.a = a;
        return c;
    }

    // -- factories --
    /// create an hsv color from the rgb color
    public static Colors.Hsv ToHsv(this Color c) {
        return new Colors.Hsv(c);
    }
}

}