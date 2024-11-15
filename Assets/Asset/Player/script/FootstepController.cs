using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Array to hold footstep sound clips
    public float minTimeBetweenFootsteps = 0.3f; // Minimum time between footstep sounds
    public float maxTimeBetweenFootsteps = 0.6f; // Maximum time between footstep sounds

    private AudioSource audioSource; // Reference to the Audio Source component
    private bool isWalking = false; // Flag to track if the player is walking
    private float timeSinceLastFootstep; // Time since the last footstep sound

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
    }

    private void Update()
    {
        if (isWalking && Time.time - timeSinceLastFootstep >= Random.Range(minTimeBetweenFootsteps, maxTimeBetweenFootsteps))
        {
            PlayFootstepSound();
        }
    }

    public void StartWalking()
    {
        isWalking = true;
    }

    public void StopWalking()
    {
        isWalking = false;
    }

    private void PlayFootstepSound()
    {
        AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
        audioSource.PlayOneShot(footstepSound);
        timeSinceLastFootstep = Time.time; // Update the time since the last footstep sound
    }
}