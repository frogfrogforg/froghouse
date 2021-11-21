using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frog2011 {

    [System.Serializable]
    public abstract class FrogInput : MonoBehaviour {
        public abstract float GetDX(); // should be from -1 to 1.
        public abstract float GetDY(); // should be from -1 to 1.
       // public bool getShake(); // for example
    }


    public class FrogController : MonoBehaviour
    {
        [SerializeField]
        public FrogInput input;
        public float moveForce = 1f;

        public bool tankControls = false;
        public float torque = 0.5f;

        [Header("Readonly")]
        public float dx;
        public float dy;


        private Rigidbody _rb;

        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();   
        }

        // Update is called once per frame
        void Update()
        {
            dx = input.GetDX();
            dy = input.GetDY();

            if (tankControls) {
                _rb.AddTorque(Vector3.up * dx * torque);
                _rb.AddForce(dy*moveForce*transform.forward);
            } else {
                _rb.AddForce(new Vector3(
                    dx,
                    0f,
                    dy
                )*moveForce);
            }


        }
    }
}
 