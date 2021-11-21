using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace MutCommon.UnityAtoms
{
    public class FloatToRange : MonoBehaviour
    {
        public FloatReference Min;
        public FloatReference Max;
        public FloatReference In;
        public FloatReference Out;

        void Awake()
        {
            Min?.GetChanged()?.Register(_ => OnChange());
            Max?.GetChanged()?.Register(_ => OnChange());
            In?.GetChanged()?.Register(_ => OnChange());
        }

        void OnChange()
          => Out.Value = Mathf.Lerp(Min.Value, Max.Value, In.Value);
    }
}