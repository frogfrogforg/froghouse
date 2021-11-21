using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Frog1997 {

/// a visual hit ring effect
public class Wet: MonoBehaviour {
    // -- tuning --
    [Header("tuning")]
    [Tooltip("the speed of the effect in u/s")]
    [SerializeField] float m_Speed = 1.0f;

    [Tooltip("the delay before the next effect")]
    [SerializeField] Linear<float> m_Delay;

    [Tooltip("the multiplier to grow the hit radius by")]
    [SerializeField] Linear<float> m_Radius;

    // -- commands --
    /// play the wet effect a number of times
    public static void Play(MonoBehaviour parent, int count = 5) {
        parent.StartCoroutine(PlayAsync(parent.transform, count));
    }

    /// play the wet effect a number of times
    static IEnumerator PlayAsync(Transform parent, int count) {
        var prefab = Single.Get.Wet;

        for (var i = 0; i < count; i++) {
            var obj = Instantiate(prefab, parent);
            var wet = obj.GetComponent<Wet>();
            wet.Play();

            yield return new WaitForSeconds(wet.m_Delay.Sample());
        }
    }

    /// play the wet effect
    void Play() {
        StartCoroutine(PlayAsync());
    }

    /// play the wet effect
    IEnumerator PlayAsync() {
        // sample radius
        var r0 = 1.0f;
        var r1 = m_Radius.Sample();

        // get duration
        var duration = Mathf.Abs(r1 - r0) / m_Speed;

        // grow the radius
        Radius()
            .Tween(r0, r1, duration)
            .SetEase(Ease.OutCubic);

        // recede into the ground
        Offset()
            .Tween(0.4f, 0.0f, duration)
            .SetEase(Ease.OutCubic);

        // remove on complete
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    // -- props/hot --
    /// a lens for the radius
    public Lens<float> Radius() {
        var t = transform;

        return new Lens<float>(
            ( ) => t.localScale.x,
            (v) => {
                var s = t.localScale;
                s.x = v;
                s.z = v;
                t.localScale = s;
            }
        );
    }

    /// a lens for the vertical offset
    public Lens<float> Offset() {
        var t = transform;

        return new Lens<float>(
            ( ) => t.position.y,
            (v) => {
                var p = t.position;
                p.y = v;
                t.position = p;
            }
        );
    }
}

}