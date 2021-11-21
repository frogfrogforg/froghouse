using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public void SpawnBubble(Vector3 pos)
    {
        print("spawning bubble");
        var a = Instantiate(prefab, pos, Quaternion.identity);
    }
}
