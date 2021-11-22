using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Frog2001
{
    public class FrogController : MonoBehaviour
    {

        private Animator anim;

        
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        // Update is called once per frameif
        void Update()
        {

           if (Input.GetKey(KeyCode.W)) {
               Debug.Log("move frog forward");
           }   
        }
    }
}
