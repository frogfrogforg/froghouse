using UnityEngine;

namespace Frog1997 {

/// the menu
public class Menu: MonoBehaviour {
    // -- deps --
    /// a reference to frog
    Frog m_Frog;

    // -- tuning --
    [Header("tuning")]
    [Tooltip("the cursor offset from the action")]
    [SerializeField] Vector2 m_CursorOffset = new Vector2(-10.0f, 0.0f);

    // -- nodes --
    [Header("nodes")]
    [Tooltip("the root transform")]
    [SerializeField] RectTransform m_Root;

    [Tooltip("the hp val")]
    [SerializeField] MenuVal m_Hp;

    [Tooltip("the mp val")]
    [SerializeField] MenuVal m_Mp;

    [Tooltip("the act progress bar")]
    [SerializeField] MenuProgress m_Act;

    [Tooltip("the limit progress bar")]
    [SerializeField] MenuProgress m_Limit;

    [Tooltip("the cursor")]
    [SerializeField] RectTransform m_Cursor;

    [Tooltip("the actions")]
    [SerializeField] MenuActions m_Actions;

    // -- lifecycle --
    void Start() {
        // set deps
        m_Frog = Single.Get.Frog;
    }

    void Update() {
        SyncFrog();
        SyncCursor();
    }

    // -- commands --
    /// update ui with frog's stats
    void SyncFrog() {
        m_Hp.Set(m_Frog.Hp);
        m_Mp.Set(m_Frog.Mp);
        m_Act.Set(m_Frog.ActPct);
        m_Limit.Set(m_Frog.LimitPct);
        m_Actions.IsVisible = m_Frog.ActPct >= 1.0f;
    }

    /// update ui with the selected action
    void SyncCursor() {
        // find the action
        var action = m_Actions.FindSelectedRect();

        // set cursor visibility
        var isVisible = action != null;
        m_Cursor.SetActive(isVisible);

        // if visible
        if (!isVisible) {
            return;
        }

        // and the parent changed
        if (m_Cursor.parent == action) {
            return;
        }

        // move it into position
        m_Cursor.SetParent(action, false);

        var pc = Vector2.zero;
        pc += m_CursorOffset;
        pc.x -= m_Cursor.rect.width;

        m_Cursor.anchoredPosition = pc;
    }

    // -- events --
    /// when an action is selected
    public void OnSelect(FrogAction data) {
        if (m_Frog.IsActReady) {
            m_Frog.Act(data);
        }
    }
}

}