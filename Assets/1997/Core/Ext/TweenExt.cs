using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace Frog1997 {

/// extensions for making tweens
public static class TweenExt {
    /// tween the lens w/ a linear value
    public static TweenerCore<float, float, FloatOptions> TweenTo(
        this Lens<float> prop,
        float src,
        Linear<float> dst
    ) {
        return prop.TweenTo(src, dst.Value, dst.Scale);
    }

    /// tween the lens
    public static TweenerCore<float, float, FloatOptions> TweenTo(
        this Lens<float> prop,
        float src,
        float dst,
        float duration
    ) {
        // set the initial value
        prop.Val = src;

        // create the tween
        var tween = DOTween.To(
            ( ) => prop.Val,
            (v) => prop.Val = v,
            dst,
            duration
        );

        return tween;
    }
}

}