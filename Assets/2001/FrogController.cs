using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Frog2001
{
    public class FrogController : MonoBehaviour
    {
        public float moveSpeed;

        private Animator anim;


        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frameif
        void Update()
        {

            //var position = transform.position;

           if (Input.GetKey(KeyCode.W)) {
               Debug.Log("move frog forward");
               transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
           }   

        

        


        }
    }
}
