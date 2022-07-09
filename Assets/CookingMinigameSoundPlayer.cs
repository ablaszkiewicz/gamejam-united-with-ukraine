using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMinigameSoundPlayer : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> clips;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickUpSound()
    {
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    public void PlayImpactSound()
    {
        audioSource.clip = clips[1];
        audioSource.Play();
    }
}
