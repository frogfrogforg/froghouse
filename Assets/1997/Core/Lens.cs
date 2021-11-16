using System;

namespace Frog1997 {

/// a type representing a mutable value
public struct Lens<T> {
    // -- props --
    /// the getter
    Func<T> m_Get;

    /// the setter
    Action<T> m_Set;

    // -- lifetime --
    public Lens(Func<T> get, Action<T> set) {
        m_Get = get;
        m_Set = set;
    }

    // -- props/hot --
    /// the value of this lens
    public T Val {
        get => m_Get.Invoke();
        set => m_Set.Invoke(value);
    }
}

}