using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
	public Vector2 scrollRate;

    public Material material;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = Time.time * scrollRate;
        material.SetTextureOffset("_MainTex", offset);
    }
}
