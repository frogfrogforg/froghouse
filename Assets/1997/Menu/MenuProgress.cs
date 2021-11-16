using UnityEngine;
using UnityEngine.UI;

namespace Frog1997 {

/// a menu progress bar
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

    // -- commands --
    /// set the current percent complete
    public void Set(float pct) {
        m_Pct = pct;
    }
}

}