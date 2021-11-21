using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace MutCommon.UnityAtoms
{
    public class Vector2Pack : MonoBehaviour
    {
        [Header("Input")]
        public FloatReference InX;
        public FloatReference InY;

        [Header("Output")]
        public Vector2Variable Out;

        // Update is called once per frame
        void Start()
        {
            SetValue();
            InX?.GetChanged()?.Register(x =>
            {
                SetValue();
            });

            InY?.GetChanged()?.Register(x =>
            {
                SetValue();
            });
        }

        void SetValue()
        {
            Out?.SetValue(new Vector2(InX.Value, InY.Value));
        }
    }
}