using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace MutCommon.UnityAtoms
{
    public class Vector2Unpack : MonoBehaviour
    {
        public Vector2Variable In;

        public FloatVariable OutX;

        public FloatVariable OutY;

        // Update is called once per frame
        void Awake()
        {
            In?.Changed.Register(_ =>
            {
                OutX?.SetValue(In.Value.x);
                OutY?.SetValue(In.Value.y);
            });
        }
    }
}