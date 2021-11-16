namespace Frog1997 {

/// native array extensions
public static class ArrayExt {
    /// fill the array
    public static T[] Fill<T>(this T[] array, T val) {
        for (var i = 0; i < array.Length; i++) {
            array[i] = val;
        }

        return array;
    }
}

}