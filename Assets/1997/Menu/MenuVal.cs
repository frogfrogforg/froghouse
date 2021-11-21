using UnityEngine;
using TMPro;

namespace Frog1997 {

/// a menu value; numeric and progress
public class MenuVal: MonoBehaviour {
    // -- config --
    [Header("config")]
    [Tooltip("if the max value is visible")]
    [SerializeField] bool m_ShowMax;

    // -- nodes --
    [Header("nodes")]
    [Tooltip("the value label")]
    [SerializeField] TMP_Text m_Label;

    [Tooltip("the progress bar")]
    [SerializeField] MenuProgress m_Bar;

    // -- commands --
    /// set the current percent complete
    public void Set(Clamp<int> c) {
        // build label
        var text = $"{c.Val}";
        if (m_ShowMax) {
            text += $" of {c.Max}";
        }

        // update ui
        m_Label.text = text;
        m_Bar.Set(Mathf.InverseLerp(c.Min, c.Max, c.Val));
    }
}

}