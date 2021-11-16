using UnityEngine;

namespace Frog1997 {

/// debugging routines
public static class D {
    /// log the value and return it
    public static T Insp<T>(string label, T val) {
        Debug.Log($"{label}: ${val}");
        return val;
    }
}

}