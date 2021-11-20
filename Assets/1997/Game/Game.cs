using UnityEngine;
using UnityEngine.Rendering;

namespace Frog1997 {

/// the game
[ExecuteAlways]
public class Game: MonoBehaviour {
    // -- config --
    [Header("config")]
    [Tooltip("the render pipeline")]
    [SerializeField] RenderPipelineAsset m_Pipeline;

    // -- props --
    /// the previous render pipeline
    RenderPipelineAsset m_PrevPipeline;

    // -- lifecyle --
    void Awake() {
        // switch the rendering pipeline
        m_PrevPipeline = GraphicsSettings.renderPipelineAsset;
        GraphicsSettings.renderPipelineAsset = m_Pipeline;
    }
}

}