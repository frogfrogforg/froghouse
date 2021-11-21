using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace MutCommon.UnityAtoms
{
    [RequireComponent(typeof(Rigidbody))]
    public class ConstantForce : MonoBehaviour
    {
        [SerializeField] private ForceMode forceMode;
        [SerializeField] private Vector3Reference force;
        [SerializeField] private BoolReference isLocal;

        [Header("Debug")]
        [SerializeField] private ColorReference gizmosColor;

        private Vector3 transformedForce => isLocal.Value ? transform.localToWorldMatrix.MultiplyVector(force.Value) : force.Value;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            rb.AddForce(transformedForce, forceMode);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = gizmosColor.Value;
            Gizmos.DrawRay(transform.position, transformedForce);
        }
    }
}