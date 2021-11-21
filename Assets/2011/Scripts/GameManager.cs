using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frog2011 {
       
    public class GameManager : MonoBehaviour
    {
        public bool paused = true;
        public KeyCode pauseKey = KeyCode.Return;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(pauseKey)) {
                paused = !paused;
            }
        }
    }
 
}