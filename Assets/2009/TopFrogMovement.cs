using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Frog2009
{

    public class TopFrogMovement : MonoBehaviour
    {
        public float DiveSpeed = 10;
        public Transform StartReference;
        public Transform UnderwaterReference;

        private bool canGoUp => transform.position.y < StartReference.position.y;

        private bool isUnderwater => transform.position.y < UnderwaterReference.position.y;


        [SerializeField]
        private BoolReference IsThisFrogUnderwater;

        [SerializeField]
        private BoolReference _IsOtherFrogUnderwater;

        private bool _showingSign = false;
        private bool showingSign
        {
            get
            {
                return _showingSign;
            }
            set
            {
                anim.SetBool("is_sign_up", value);
                _showingSign = value;
            }
        }

        private Animator anim;
        // Start is called before the first frame update
        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_IsOtherFrogUnderwater.Value) return;
            var position = transform.position;
            if (!isUnderwater)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    position += Vector3.down * DiveSpeed * Time.deltaTime;
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    showingSign = !showingSign;
                }
            }

            if (canGoUp && Input.GetKey(KeyCode.W))
            {
                position += Vector3.up * DiveSpeed * Time.deltaTime;
            }

            IsThisFrogUnderwater.Value = isUnderwater;

            transform.position = position;
        }
    }
}