using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frog2011 {

    [System.Serializable]
    public abstract class FrogInput : MonoBehaviour {
        public abstract float GetDX(); // should be from -1 to 1.
        public abstract float GetDY(); // should be from -1 to 1.
        public abstract float GetViolence(); // should be from 0 to 1.
       // public bool getShake(); // for example
    }


    public class FrogController : MonoBehaviour
    {
        [SerializeField]
        public FrogInput input;
        public float moveForce = 1f;

        public bool tankControls = false;

        public float riverVelocity = 0.5f;

        public float violenceDuration = 8f;
        public float violenceScaleFactor = 1f;
        public float violenceSpeedup = 1.2f;

        public FrogController otherFrog;

        public Renderer rend;
        public GameObject violenceText;

        [Header("Readonly")]
        public float dx;
        public float dy;
        public float violence;

        public int nGems = 1;



        private Rigidbody _rb;

        private float violenceStartTime = -1f;
        private bool doingViolence = false;

        private Vector3 initScale;
        private Color initColor;

        private Animator _animator;

        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();   
            initScale = transform.localScale;
            initColor = rend.materials[1].color;

            violenceText.SetActive(false);

            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (nGems >= 3) {
                VIOLENCE();
            }

            dx = input.GetDX();
            dy = input.GetDY();
            violence = input.GetViolence();

            float _moveForce = moveForce;

            if (doingViolence) {
                if (Time.time - violenceStartTime < violenceDuration) {
                    rend.materials[1].color = Mathf.Repeat(Time.time*10f, 1f) > 0.5f ? initColor : Color.white;

                    // TODO screenshake proportional to shake input

                    transform.localScale = initScale + initScale*violenceScaleFactor*violence;

                    _moveForce = _moveForce + violenceSpeedup*violence;

                    violenceText.SetActive(true);
                } else {
                    doingViolence = false;
                }
            } else {
                transform.localScale = initScale;
                rend.materials[1].color = initColor;

                violenceText.SetActive(false);
            }

            if (tankControls) {
                //_rb.AddTorque(Vector3.up * dx * torque);
                _rb.AddForce(dy*moveForce*transform.forward);
                Quaternion targetRotation = Quaternion.Euler(0f, dx*80f, 0f);
                _rb.MoveRotation(targetRotation);
            } else {
                _rb.AddForce(new Vector3(
                    dx,
                    0f,
                    dy
                )*moveForce);
            }

            _animator.SetFloat("Speed", dy+0.4f);

            _rb.AddForce(Vector3.back*riverVelocity, ForceMode.VelocityChange);
        }

        void OnTriggerEnter(Collider c) {
            //Debug.Log("OnTriggerEnter " + c.gameObject.name);
            if (c.gameObject.name == "Gem") {
                nGems++;
                Destroy(c.gameObject);
            }
        }

        void OnCollisionEnter(Collision c) {
            if (doingViolence && violence > 0.25f) {
                Destroy(c.gameObject);
            }
         }

        void VIOLENCE() {
            Debug.Log("Violence");
            violenceStartTime = Time.time;
            doingViolence = true;
            nGems = 0;
            otherFrog.nGems = 0;
        }
    }
}
 