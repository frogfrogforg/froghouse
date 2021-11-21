using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class Bubble : MonoBehaviour
{
    public FloatReference gravity;
    private Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        velocity += Vector3.up * gravity.Value * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}
