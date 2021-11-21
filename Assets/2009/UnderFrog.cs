using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Frog2009
{
    public class UnderFrog : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform TopReference;
        [SerializeField] private Camera viewCam;

        private Vector3 forward => Vector3.ProjectOnPlane(
            viewCam.transform.forward,
            up);
        private Vector3 right => viewCam.transform.right;
        private Vector3 up => Vector3.up;


        private bool _isUnderwater => transform.position.y < TopReference.position.y;

        [SerializeField]
        private BoolReference IsThisFrogUnderwater;

        [Header("ExternalReferences")]
        [SerializeField]
        private BoolReference _IsOtherFrogUnderwater;

        // Update is called once per frame
        void Update()
        {
            IsThisFrogUnderwater.Value = _isUnderwater;
            if (!_IsOtherFrogUnderwater.Value) return;

            var pos = transform.position;
            if (Input.GetKey(KeyCode.A))
            {
                pos -= right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                pos += right * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                pos -= up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.W))
            {
                pos += up * speed * Time.deltaTime;
            }

            transform.position = pos;
        }
    }
}