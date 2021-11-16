using UnityEngine;
using UnityEngine.UI;

namespace Frog1997 {

/// the menu
public class MenuProgress : MonoBehaviour {
    // -- nodes --
    [Header("nodes")]
    [Tooltip("the enclosing rect")]
    [SerializeField] RectTransform m_Rect;

    [Tooltip("the mask for the bar")]
    [SerializeField] RectMask2D m_Mask;

    // -- props --
    /// the current percent complete
    float m_Pct;

    // -- lifecycle --
    void Update() {
        // draw bar
        var p = m_Mask.padding;
        p.z = m_Rect.rect.width * (1.0f - m_Pct);
        m_Mask.padding = p;
    }

    // -- props/hot --
    /// the current percent complete
    public float Pct {
        get => m_Pct;
        set => m_Pct = value;
    }
}

}