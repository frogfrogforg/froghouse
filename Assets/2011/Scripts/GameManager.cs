using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frog2011 {
       
    public class GameManager : MonoBehaviour
    {
        //public bool paused = true;
        //public KeyCode pauseKey = KeyCode.Return;
        public KeyCode restartKey = KeyCode.Return;
        public GameObject game;

        private GameObject startingState;
        // Start is called before the first frame update
        void Start()
        {
            startingState = Instantiate(game);
            startingState.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            // if (Input.GetKeyDown(pauseKey)) {
            //     paused = !paused;
            //     game.SetActive(!paused);
            // }
            if (Input.GetKeyDown(restartKey)) {
                Destroy(game);
                startingState.SetActive(true);
                game = startingState;

                startingState = Instantiate(game);
                startingState.SetActive(false);
            }
        }
    }
 
}