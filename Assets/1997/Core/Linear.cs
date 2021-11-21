using System;
using UnityEngine;
using U = UnityEngine;

namespace Frog1997 {

/// the params for a linear equation
[Serializable]
public struct Linear<T> {
    // -- props --
    [Tooltip("a destination value")]
    public T Value;

    [Tooltip("a scale. interpretation is context-dependent.")]
    public float Scale;

    // -- lifetime --
    /// create a new linear value
    public Linear(T val, float scale) {
        Value = val;
        Scale = scale;
    }

    // -- factories --
    /// creates a "zero" value
    public static Linear<T> Zero {
        get => new Linear<T>(default, 0.0f);
    }
}

/// linear extensions
public static class LinearExt {
    /// samples a random value from the linear float (value is min, scale is len)
    public static float Sample(this Linear<float> l) {
        return l.Value + U.Random.value * l.Scale;
    }
}

}