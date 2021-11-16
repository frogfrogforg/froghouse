using UnityEngine;

namespace Frog1997 {

/// the menu
public class Menu : MonoBehaviour {
    // -- deps --
    /// a reference to frog
    Frog m_Frog;

    // -- nodes --
    [Header("nodes")]
    [Tooltip("the hp val")]
    [SerializeField] MenuVal m_Hp;

    [Tooltip("the mp val")]
    [SerializeField] MenuVal m_Mp;

    [Tooltip("the act progress bar")]
    [SerializeField] MenuProgress m_Act;

    [Tooltip("the limit progress bar")]
    [SerializeField] MenuProgress m_Limit;

    // -- lifecycle --
    void Start() {
        // set deps
        m_Frog = Single.Get.Frog;
    }

    void Update() {
        SyncFrog();
    }

    // -- commands --
    /// update ui with frog's stats
    void SyncFrog() {
        m_Hp.Set(m_Frog.Hp);
        m_Mp.Set(m_Frog.Mp);
        m_Act.Set(m_Frog.ActPct);
        m_Limit.Set(m_Frog.LimitPct);
    }
}

}