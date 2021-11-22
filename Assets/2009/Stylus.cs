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
        [SerializeField] private FloatReference epsilon;
        [SerializeField] private bool isGoingDown;
        [SerializeField] private BoolReference isDown;
        public Vector2Event screenTouchedEvent;


        [Header("Debug")]

        public Vector3 velocity;

        public RaycastHit lastHit;
        public Vector3 target;

        private Vector3 downOffset => isGoingDown ? Vector3.zero : offset;

        public Vector3 initialPosition;
        private void Awake()
        {
            lastHit.point = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
            }


            isGoingDown = Input.GetKey(KeyCode.Mouse0);
            var direction = camReference.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(direction, out var hit, 1000, BottomScreen))
            {
                lastHit = hit;
            }

            target = lastHit.point + downOffset;

            if (isGoingDown && Vector3.Distance(transform.position, target) < epsilon)
            {
                if (!isDown.Value)
                {
                    isDown.Value = true;
                    screenTouchedEvent.Raise(lastHit.textureCoord);
                }
            }
            else
            {
                isDown.Value = false;
            }

            var delta = (target - transform.position);
            var accel = Spring * delta - Damp * velocity;
            velocity += accel * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;



        }
    }
}
