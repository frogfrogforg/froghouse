using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject EndPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
           Application.LoadLevel(0);

        }
        
    }

    private void OnTriggerEnter(Collider col){
        if(col.tag=="Player"){

            Time.timeScale=0;
            EndPanel.SetActive(true);
        }
    }
}
