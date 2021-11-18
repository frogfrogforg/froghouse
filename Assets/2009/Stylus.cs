using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Frog2009
{
    public class Stylus : MonoBehaviour
    {

        public LayerMask BottomScreen;
        public float Spring;
        public float Damp;
        public Vector3 offset;
        [SerializeField] private Camera camReference;
        [SerializeField] private BoolReference isDown;


        public Vector2Event screenTouchedEvent;
        [Header("Debug")]

        public Vector3 velocity;

        public Vector3 lastHit;
        public Vector3 target;

        private Vector3 downOffset => isDown ? Vector3.zero : offset;

        private void Awake()
        {
            lastHit = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                // screenTouchedEvent.Raise();
            }

            isDown.Value = Input.GetKey(KeyCode.Mouse0);
            var direction = camReference.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(direction, out var hit, 1000, BottomScreen))
            {
                lastHit = hit.point;
            }

            target = lastHit + downOffset;

            var delta = (target - transform.position);
            var accel = Spring * delta - Damp * velocity;
            velocity += accel * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;



        }
    }
}
