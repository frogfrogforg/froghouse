using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMananger : MonoBehaviour
{
    public GameManager gm;
    public GameObject frog;
    Animator frogAnimator;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        frogAnimator = frog.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Triggered!!!!!!!!!");
        Debug.Log(other.gameObject.tag);

        if(other.gameObject.tag == "Bullets")
        {
            gm.IncreasePlayerScore(20);
            frogAnimator.SetTrigger("LowerTarget");

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided!!!!!!!!!");
    }
}
