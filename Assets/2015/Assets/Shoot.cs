using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform worldTransform;
    public Transform gunTip;
    public GameObject projectile;
    public float bulletSpeed = 2f;
    public Camera playerCam;
    Rigidbody projectileRB;
    GameObject _projectile;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        projectileRB = projectile.GetComponent<Rigidbody>();

    }

    
    Vector3 directionVector;
    // Update is called once per frame
    void Update()
    {
        var directionRay = playerCam.ScreenPointToRay(Input.mousePosition);
        var hasHit = Physics.Raycast(directionRay, out RaycastHit raycastHit);
        var directionRayVec = directionRay.direction;
        var hitPoint = raycastHit.point;
        directionVector = hitPoint - transform.position;
        if(!hasHit)
        {
            
            transform.rotation = Quaternion.LookRotation(directionRayVec.normalized);
            // gunTip.transform.rotation = Quaternion.LookRotation((hitPoint - gunTip.transform.position).normalized);
            // transform.LookAt(hitPoint);
        }
        else if(hasHit)
        {
            // transform.rotation = Quaternion.LookRotation(directionRayVec.normalized);
            gunTip.transform.rotation = Quaternion.LookRotation((hitPoint - gunTip.transform.position).normalized);
            transform.LookAt(hitPoint);
        }


        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootPelet();
        }
        
    }

    void ShootPelet()
    {
        _projectile = Instantiate(projectile,gunTip.transform.position, Quaternion.identity);
        projectileRB = _projectile.GetComponent<Rigidbody>();
        projectileRB.transform.parent = worldTransform;
        projectileRB.AddForce((gunTip.forward * bulletSpeed), ForceMode.Impulse);
    }

    


}
