using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace MutCommon.UnityAtoms
{
    public class AxisInput2d : MonoBehaviour
    {
        [Header("Output")]
        [SerializeField] private Vector2Reference Output;

        // Update is called once per frame
        void Update()
        {
            Output.Value = new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")
            );
        }
    }
}