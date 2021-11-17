using UnityEngine;

namespace Frog1997 {

/// the actions menu
public class MenuActions: MonoBehaviour {
    // -- nodes --
    [Header("nodes")]
    [Tooltip("the options panel")]
    [SerializeField] GameObject m_Panel;

    [Tooltip("the options labels")]
    [SerializeField] RectTransform[] m_Options;

    // -- props --
    /// the index of the selected action
    int m_Selected = 0;

    /// if the actions are visible
    Draft<bool> m_IsVisible;

    // -- lifecycle --
    void Awake() {
        gameObject.SetActive(m_IsVisible.Val);
    }

    void Update() {
        if (m_IsVisible.IsDirty) {
            m_IsVisible.Clean();
        }
    }

    // -- queries --
    /// finds the selected action, if any
    public RectTransform FindSelected() {
        // if visible
        if (!IsVisible) {
            return null;
        }

        // use the selected option
        return m_Options[m_Selected];
    }

    // -- props/hot --
    /// if the actions are visible
    public bool IsVisible {
        get => m_IsVisible.Val;
        set {
            m_IsVisible.Val = value;

            // set active when visibility flips
            if (m_IsVisible.IsDirty) {
                gameObject.SetActive(m_IsVisible.Val);
            }
        }
    }
}

}