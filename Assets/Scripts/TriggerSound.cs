using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioSource hitSound;
    
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        hitSound.Play();
    }
}
