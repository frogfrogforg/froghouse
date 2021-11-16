using System.Collections;
using System.Collections.Generic;

namespace Frog1997 {

/// a buffer that stores the most recent n values
public sealed class Buffer<T>: IEnumerable<T> {
    // -- props --
    /// the current start index
    int m_I;

    /// the buffered values
    readonly T[] m_Values;

    // -- lifetime --
    /// construct a buffer w/ the specified length
    public Buffer(uint length) {
        m_I = -1;
        m_Values = new T[length];
    }

    // -- commands --
    /// add a value to the buffer
    public void Add(T val) {
        var j = (m_I + 1) % m_Values.Length;
        m_I = j;
        m_Values[j] = val;
    }

    // -- queries --
    /// the most recent value
    public T Val {
        get => this[0];
    }

    /// the value from most to least recent
    public T this[int i] {
        get {
            var n = m_Values.Length;
            var j = (m_I + n - i) % n;
            return m_Values[j];
        }
    }

    // -- q/IEnumerable --
    public IEnumerator<T> GetEnumerator() {
        // enumerate from most recent to least recent
        for (var i = 0; i < m_Values.Length; i++) {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}

}