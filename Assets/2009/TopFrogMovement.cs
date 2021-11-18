using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frog2009
{

    public class TopFrogMovement : MonoBehaviour
    {
        public float DiveSpeed = 10;
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
            var position = transform.position;
            if (Input.GetKeyDown(KeyCode.S))
            {
                position += Vector3.down * DiveSpeed * Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                showingSign = !showingSign;
            }
        }
    }
}