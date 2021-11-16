namespace Frog1997 {

/// a value in a range; a thing that can be clamped
public struct Clamp<T> {
    // -- props --
    /// the current value
    public readonly T Val;

    /// the min value
    public readonly T Min;

    /// the max value
    public readonly T Max;

    // -- lifetime --
    /// create a new clamped value
    public Clamp(T val, T max, T min = default) {
        Val = val;
        Min = min;
        Max = max;
    }
}

}