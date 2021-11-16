using System;
using UnityEngine;

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

}