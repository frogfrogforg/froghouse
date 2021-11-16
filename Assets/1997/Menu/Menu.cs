using UnityEngine;

namespace Frog1997 {

/// the menu
public class Menu : MonoBehaviour {
    // -- nodes --
    [Header("nodes")]
    [Tooltip("the limit progress bar")]
    [SerializeField] MenuProgress m_Limit;

    [Tooltip("the time progress bar")]
    [SerializeField] MenuProgress m_Time;

    // -- lifecycle --
    void Update() {
        m_Limit.Pct = Time.time / 30.0f;
        m_Time.Pct = Mathf.Repeat(Time.time, 5.0f) / 5.0f;
    }
}

}