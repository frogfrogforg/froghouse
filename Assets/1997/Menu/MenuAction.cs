using UnityEngine;
using TMPro;

namespace Frog1997 {

/// a menu action
[ExecuteAlways]
public class MenuAction: MonoBehaviour {
    // -- config --
    [Header("config")]
    [Tooltip("the frog action")]
    [SerializeField] FrogAction m_Data;

    // -- nodes --
    [Header("nodes")]
    [Tooltip("the root transform")]
    [SerializeField] RectTransform m_Root;

    [Tooltip("the label")]
    [SerializeField] TMP_Text m_Label;


    // -- lifecycle --
    void Awake() {
        Hydrate();
    }

    void Update() {
        if (!Application.isPlaying) {
            Hydrate();
        }
    }

    // -- commands --
    /// hyrdate the action w/ data
    void Hydrate() {
        var a = m_Data;
        m_Label.text = m_Data?.Label ?? "";
    }

    // -- queries --
    /// the rect transform
    public RectTransform Rect {
        get => m_Root;
    }

    /// the rect transform
    public FrogAction Data {
        get => m_Data;
    }
}

}
