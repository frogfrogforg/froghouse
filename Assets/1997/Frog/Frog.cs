using UnityEngine;

namespace Frog1997 {

public class Frog: MonoBehaviour {
    // -- nodes --
    [Header("nodes")]
    [Tooltip("the animator")]
    [SerializeField] Animator m_Animator;

    // -- lifecycle --
    void Start() {
        // m_Animator.Play("Idle");
    }
}

}
