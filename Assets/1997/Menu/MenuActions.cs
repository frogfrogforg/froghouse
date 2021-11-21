using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Frog1997 {

/// the actions menu
public class MenuActions: MonoBehaviour {
    // -- config --
    [Header("config")]
    [Tooltip("the action select event")]
    [SerializeField] UnityEvent<FrogAction> m_OnSelect;

    // -- nodes --
    [Header("nodes")]
    [Tooltip("the options panel")]
    [SerializeField] GameObject m_Panel;

    [Tooltip("the options labels")]
    [SerializeField] MenuAction[] m_Options;

    [Tooltip("the audio source")]
    [SerializeField] AudioSource m_Audio;

    // -- props --
    /// the index of the selected action
    int m_Selected;

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

    // -- commands --
    /// toggle the menu on/off
    void Toggle(bool visible) {
        // update state
        m_IsVisible.Val = visible;

        // if state changed
        if (!m_IsVisible.IsDirty) {
            return;
        }

        // update go
        gameObject.SetActive(visible);

        // reset state
        if (visible) {
            m_Selected = 0;
        }
    }

    /// move menu by offset
    void Move(int offset) {
        // if visible
        if (!m_IsVisible.Val) {
            return;
        }

        var i = m_Selected;
        var n = m_Options.Length;
        m_Selected = (n + i + offset) % n;
    }

    // -- queries --
    /// finds the selected rect, if any
    public RectTransform FindSelectedRect() {
        return FindSelected()?.Rect;
    }

    /// finds the selected action, if visible
    MenuAction FindSelected() {
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
        set => Toggle(value);
    }

    // -- events --
    public void OnNavigate(InputAction.CallbackContext evt) {
        if (!IsVisible) {
            return;
        }

        var dir = -evt.ReadValue<Vector2>().y;
        Move((int)dir);

        m_Audio.Play();
    }

    public void OnSubmit(InputAction.CallbackContext evt) {
        if (!IsVisible) {
            return;
        }

        var action = FindSelected();
        if (action != null) {
            m_OnSelect.Invoke(action.Data);
        }
    }
}

}