using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMinigameSoundPlayer : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> clips;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDashSound()
    {
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    public void PlayCrashSound()
    {
        audioSource.clip = clips[1];
        audioSource.Play();
    }
}
