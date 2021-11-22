using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace MutCommon
{
    public class DestroyGameObject : MonoBehaviour
    {
        public void SelfDestroyNextFrame()
          => this.DoNextFrame(SelfDestroy);

        public void DestroyOtherNextFrame(GameObject go)
          => this.DoNextFrame(() => DestroyOther(go));

        public void DestroyOther(GameObject go)
          => Destroy(go);

        public void DestroyOther(GameObjectVariable go)
        => Destroy(go.Value);

        public void SelfDestroy()
          => Destroy(this.gameObject);
    }
}