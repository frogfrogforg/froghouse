using UnityAtoms;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace MutCommon.UnityAtoms
{
    public class Vector3Pack : MonoBehaviour
    {
        [Header("Input")]
        public FloatReference InX;
        public FloatReference InY;
        public FloatReference InZ;

        [Header("Output")]
        public Vector3Variable Out;

        // Update is called once per frame
        void Start()
        {
            SetValue();
            InX?.GetChanged()?.Register(_ =>
            {
                SetValue();
            });

            InY?.GetChanged()?.Register(_ =>
            {
                SetValue();
            });

            InZ?.GetChanged()?.Register(_ =>
            {
                SetValue();
            });
        }

        void SetValue()
        {
            Out?.SetValue(new Vector3(InX.Value, InY.Value, InZ.Value));
        }
    }
}