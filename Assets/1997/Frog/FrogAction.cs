using UnityEngine;

namespace Frog1997 {

/// a frog action
[CreateAssetMenu(fileName = "FrogAction", menuName = "Data/Frog/Action", order = 1)]
public class FrogAction: ScriptableObject {
    /// -- types --
    /// the action kind
    public enum Type {
        Fight,
        Wet,
        Flea
    }

    // -- fields --
    [Header("fields")]
    [Tooltip("the action kind")]
    [SerializeField] Type m_Kind;

    [Tooltip("the action label")]
    [SerializeField] string m_Label;

    [Tooltip("the action data")]
    [SerializeField] Object m_Data;

    // -- queries --
    /// the action kind
    public Type Kind {
        get => m_Kind;
    }

    /// the action label
    public string Label {
        get => m_Label;
    }

    /// the action data, if any
    public T Data<T>() where T: ScriptableObject {
        return m_Data as T;
    }
}

}
