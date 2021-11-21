using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace MutCommon.UnityAtoms
{

    public class PlayerInputAxisCamera : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool raw;
        [Header("References")]
        [SerializeField]
        private GameObjectReference cameraReference;
        [Header("Output")]
        [SerializeField]
        private Vector3Reference output;

        Func<string, float> getAxis
        {
            get
            {
                if (raw) return Input.GetAxisRaw;
                return Input.GetAxis;
            }
        }

        // Update is called once per frame
        void Update()
        {
            var forward = Vector3.ProjectOnPlane(
              cameraReference.Value.transform.forward,
              Vector3.up).normalized;
            var right = cameraReference.Value.transform.right;

            output.Value =
                  getAxis("Horizontal") * right
                  +
                  getAxis("Vertical") * forward;
        }
    }
}