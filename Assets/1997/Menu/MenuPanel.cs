using UnityEngine;
using UnityEngine.UI;

namespace Frog1997 {

/// a menu panel
[ExecuteAlways]
public class MenuPanel: MonoBehaviour {
    // -- constants --
    static readonly Color s_Color = new Color(0.5934051f, 0.7999424f, 0.990566f, 0.3921569f);

    // -- lifecycle --
    void Awake() {
        Style();
    }

    void Update() {
        if (!Application.isPlaying) {
            Style();
        }
    }

    // -- commands --
    /// style the panel
    void Style() {
        var bg = GetComponent<Image>();
        bg.sprite = null;
        bg.color = s_Color;
    }
}

}