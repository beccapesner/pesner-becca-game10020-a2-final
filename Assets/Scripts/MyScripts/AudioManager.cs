using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip maxFearSound;
    public AudioClip hallwayEnterSound;
    public AudioClip hallwayExitSound;
    
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
    }
    

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    
    public void MaxFearSound()
    {
        PlaySound(maxFearSound);
    }

    public void EnterHallwaySound()
    {
        PlaySound(hallwayEnterSound);
    }

    public void ExitHallwaySound()
    {
        PlaySound(hallwayExitSound);
    }
}
