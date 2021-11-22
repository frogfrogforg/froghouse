using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Frog2001
{
    public class FrogController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            
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
