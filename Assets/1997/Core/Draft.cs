using System;

namespace Frog1997 {

/// a thing that can change and tracks changes
public struct Draft<T> where T: IEquatable<T> {
    // -- props --
    /// the value
    T m_Value;

    /// if last mutation changed the value
    bool m_IsDirty;

    // -- lifetime --
    /// create a draft with an initial value
    public Draft(T value) {
        m_Value = value;
        m_IsDirty = false;
    }

    // -- props/hot --
    /// the underlying value
    public T Val {
        get => m_Value;
        set {
            var prev = m_Value;
            m_Value = value;
            m_IsDirty = !prev.Equals(value);
        }
    }

    /// if this value is dirty
    public bool IsDirty {
        get => m_IsDirty;
    }
}

}