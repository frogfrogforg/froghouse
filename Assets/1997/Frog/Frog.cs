using UnityEngine;

namespace Frog1997 {

/// the final frog
public class Frog: MonoBehaviour {
    // -- tuning --
    [Header("tuning")]
    [Tooltip("the max hp")]
    [SerializeField] int m_HpMax = 200;

    [Tooltip("the max mp")]
    [SerializeField] int m_MpMax = 75;

    [Tooltip("the act speed in pct / s")]
    [SerializeField] float m_ActSpeed = 1.0f / 3.0f;

    [Tooltip("the limit speed in pct / s")]
    [SerializeField] float m_LimitSpeed = 1.0f / 30.0f;

    // -- nodes --
    [Header("nodes")]
    [Tooltip("the animator")]
    [SerializeField] Animator m_Animator;

    // -- props --
    /// the current hp
    int m_Hp;

    /// the current mp
    int m_Mp;

    /// the act percent
    float m_ActPct;

    /// the limit percent
    float m_LimitPct;

    // -- lifecycle --
    void Start() {
        // set props
        m_Hp = m_HpMax;
        m_Mp = m_MpMax;
    }

    void Update() {
        Tick();
    }

    // -- commands --
    /// perform an action
    public void Act(FrogAction action) {
        // reset timer
        m_ActPct = 0.0f;

        // perform action
        switch (action.Kind) {
        case FrogAction.Type.Fight:
            ActFight(); break;
        case FrogAction.Type.Wet:
            ActWet(); break;
        case FrogAction.Type.Flea:
            ActFlea(); break;
        };
    }

    /// perform the wet action
    void ActFight() {
        m_Animator.SetTrigger("Fight");
    }

    /// perform the wet action
    void ActWet() {
        Wet.Play(this);
        m_Animator.SetTrigger("Wet");
    }

    /// perform the flea action
    void ActFlea() {
        m_Animator.SetTrigger("Flea");
    }

    /// update any periodic stats
    void Tick() {
        var t = Time.deltaTime;
        m_ActPct = Mathf.Clamp01(m_ActPct + m_ActSpeed * t);
        m_LimitPct = Mathf.Clamp01(m_LimitPct + m_LimitSpeed * t);
    }

    // -- queries --
    /// the current hp
    public Clamp<int> Hp {
        get => new Clamp<int>(m_Hp, m_HpMax);
    }

    /// the current mp
    public Clamp<int> Mp {
        get => new Clamp<int>(m_Mp, m_MpMax);
    }

    /// the current act percent
    public float ActPct {
        get => m_ActPct;
    }

    /// the current limit percent
    public float LimitPct {
        get => m_LimitPct;
    }

    /// if the frog is ready to act
    public bool IsActReady {
        get => m_ActPct >= 1.0f;
    }
}

}
