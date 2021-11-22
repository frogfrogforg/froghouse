using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPetFrog : MonoBehaviour
{
    public List<Material> frogMaterials;
    public AudioClip frogPetSound;
    public bool frogUpDown;

    private Animator anim;
    private SkinnedMeshRenderer smr;
    private Material[] mats;
    private AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        smr = GetComponent<SkinnedMeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        mats = smr.materials;
    }

    private void Update()
    {
        anim.SetBool("frogUpDown", frogUpDown);
    }

    public void SendFrogUp(int frogNum)
    {
        mats[3] = frogMaterials[frogNum];
        smr.materials = mats;
        frogUpDown = true;
    }

    public void SendFrogDown()
    {
        frogUpDown = false;
    }

    private void OnMouseDown()
    {
        audioSource.PlayOneShot(frogPetSound);
    }
}
