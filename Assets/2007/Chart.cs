using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col){
        if(col.tag=="Player"){
            col.transform.parent=transform;
            
        }
    }
}
