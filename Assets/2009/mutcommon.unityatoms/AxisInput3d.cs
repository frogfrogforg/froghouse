using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace MutCommon.UnityAtoms
{
    public class AxisInput3d : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool raw;
        [Header("Output")]
        [SerializeField] private Vector3Reference Output;

        void Update()
        {
            Output.Value = new Vector3(
                raw ? Input.GetAxisRaw("Horizontal") : Input.GetAxis("Horizontal"),
                0,
                raw ? Input.GetAxisRaw("Vertical") : Input.GetAxis("Vertical")
            );
        }
    }
}