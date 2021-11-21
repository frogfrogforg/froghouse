using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace Frog2009
{
    [RequireComponent(typeof(Camera))]
    public class BottomCameraEventHandler : MonoBehaviour
    {
        [SerializeField] private Vector3Event raycastPlane;
        [SerializeField] private LayerMask planeLayer;
        private Camera cam;
        private void Awake()
        {
            cam = GetComponent<Camera>();
        }

        public void HandleBottomScreenClick(Vector2 click)
        {
            var ray = cam.ViewportPointToRay(new Vector3(click.x, click
            .y, 0));
            if (Physics.Raycast(ray, out var hit, 1000, planeLayer))
            {
                raycastPlane?.Raise(hit.point);
            }
        }
    }
}
