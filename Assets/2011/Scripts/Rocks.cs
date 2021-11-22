using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frog2011 {
    public class Rocks : MonoBehaviour
    {
        public float moveSpeed = 0.1f;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Time.deltaTime*moveSpeed*Vector3.back);
        }
    }

}
