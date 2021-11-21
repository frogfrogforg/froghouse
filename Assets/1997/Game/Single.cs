using UnityEngine;

namespace Frog1997 {

/// a container for modules
public sealed class Single: MonoBehaviour {
    // -- module --
    /// the shared instance
    static Single s_Get;

    /// get the module
    public static Single Get {
        get => s_Get;
    }

    // -- modules --
    [Header("modules")]
    [Tooltip("the shared frog")]
    [SerializeField] Frog m_Frog;

    [Tooltip("the shared wet effect prefab")]
    [SerializeField] GameObject m_Wet;

    // -- lifecycle --
    void Awake() {
        if (s_Get == null) {
            s_Get = this;
        }
    }

    // -- queries --
    /// the shared frog
    public Frog Frog {
        get => m_Frog;
    }

    /// the shared wet effect prefab
    public GameObject Wet {
        get => m_Wet;
    }
}

}