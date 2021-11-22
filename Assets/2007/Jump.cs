using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float speed =5,timeCount;
    private Rigidbody rb;
    public LayerMask groundLayers;
    public float jumpForce;
    public Collider col;
    public Vector2 turn;
    public Vector3 destination;
    #region Monobehaviour API
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        col=GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        turn.y+=Input.GetAxis("Mouse X");
        transform.localRotation=Quaternion.Euler(0,-turn.y,0);
         if(Input.GetKey(KeyCode.W)) {
             transform.position += transform.forward * Time.deltaTime * speed;
         }
         else if(Input.GetKey(KeyCode.S)) {
             GetComponent<Rigidbody>().position -=transform.forward  * Time.deltaTime * speed;
         }
        if(Input.GetKey(KeyCode.Space)){
            timeCount+=Time.deltaTime;
            jumpForce+=Time.deltaTime;


        }
        if(Input.GetKeyUp(KeyCode.Space)){
            rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            rb.AddForce(transform.forward*jumpForce*0.5f,ForceMode.Impulse);
            jumpForce=7;
            timeCount=0;
        }
    }
        private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), 1, groundLayers);
   }
        
    
    #endregion
}
