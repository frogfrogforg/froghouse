using UnityEngine;

namespace Frog1997 {

/// unity curve extensions
public static class CurveExt {
    // -- queries --
    /// the last key in the curve
    public static Keyframe Last(this AnimationCurve c) {
        return c.keys[c.length - 1];
    }

    /// the duration of the curve
    public static float Duration(this AnimationCurve c) {
        return c.Last().time;
    }

    /// sample a random value from the curve
    public static float Sample(this AnimationCurve c) {
        return c.Evaluate(Random.value);
    }

    /// sample a random value from the curve
    public static int SampleInt(this AnimationCurve c) {
        return Mathf.FloorToInt(c.Sample());
    }

    // -- factoires --
    /// an linear curve from 0 to 1
    public static AnimationCurve One() {
        return AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
    }
}

}