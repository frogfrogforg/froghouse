using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FrogHop : MonoBehaviour
{
    public Vector2 xMoveMinMax;
    public Vector2 zMoveMinMax;
    public Vector2 restTimeMinMax;
    public float speed = 1;
    public Animator anim;
    public TestPetFrog petFrog;
    
    bool moving;
    private Vector3 goalDestination;
    private Vector3 startDestination;
    private float restTime;
    private float restTimer = 0;
    float t;
    public bool frogCalled;

    private void Start()
    {
        restTime = Random.Range(restTimeMinMax.x, restTimeMinMax.y);
    }

    private void Update()
    {
        anim.SetBool("moving", moving);
        if (moving)
        {
            transform.position = Vector3.Lerp(startDestination, goalDestination, t);
            if (t <= 1)
            {
                t += (Time.deltaTime * speed);
            }else if (t >= 1)
            {
                if (frogCalled)
                {
                    if (!petFrog.frogUpDown)
                    {
                        petFrog.SendFrogUp(nintenfrogManager.instance.calledFrogNum);
                    }
                }
                else
                {
                    moving = false;
                    restTime = Random.Range(restTimeMinMax.x, restTimeMinMax.y);
                    restTimer = 0;
                    t = 0;
                }
            }
        }
        else
        {
            if (restTimer >= restTime)
            {
                MoveFrog();
            }
            else
            {
                restTimer += Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnCallFrog();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OnReturnFrog();
        }
        
    }

    public void MoveFrog(){
        if (!moving)
        {
            moving = true;
            startDestination = transform.position;
            float xDestination = Random.Range(xMoveMinMax.x, xMoveMinMax.y);
            float zDestination = Random.Range(zMoveMinMax.x, zMoveMinMax.y);
            goalDestination = new Vector3(xDestination, 0, zDestination);
            transform.LookAt(goalDestination);
        }
    }

    public void OnCallFrog()
    {
        frogCalled = true;
        moving = true;
        startDestination = transform.position;
        goalDestination = new Vector3(0, 0, -2);
        transform.LookAt(goalDestination);
    }

    public void OnReturnFrog()
    {
        petFrog.SendFrogDown();
        frogCalled = false;
    }
    
}
