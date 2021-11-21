using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Frog2009
{

    public class BubbleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        public void SpawnBubble(Vector3 pos)
        {
            var a = Instantiate(prefab, pos, Quaternion.identity, transform);
        }
    }
}