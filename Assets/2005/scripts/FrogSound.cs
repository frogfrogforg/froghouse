using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip frogWalk;
    public FrogHop frogHop;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SoundOnWalk()
    {
        if (!frogHop.frogCalled)
        {
            audioSource.PlayOneShot(frogWalk);
        }
        
    }
}
