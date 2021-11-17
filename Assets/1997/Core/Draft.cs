using System;

namespace Frog1997 {

/// a thing that can change and tracks changes
public struct Draft<T> where T: IEquatable<T> {
    // -- props --
    /// the value
    T m_Val;

    /// if last mutation changed the value
    bool m_IsDirty;

    // -- lifetime --
    /// create a draft with an initial value
    public Draft(T value = default) {
        m_Val = value;
        m_IsDirty = false;
    }

    // -- commands --
    /// marks the draft as clean
    public void Clean() {
        m_IsDirty = false;
    }

    // -- queries --
    /// gets the value once and flags it as clean; (check `IsDirty` first)
    public T Once() {
        Clean();
        return m_Val;
    }

    // -- props/hot --
    /// the underlying value
    public T Val {
        get => m_Val;
        set {
            var prev = m_Val;
            m_Val = value;
            m_IsDirty = !prev.Equals(value);
        }
    }

    /// if this value is dirty
    public bool IsDirty {
        get => m_IsDirty;
    }
}

}