using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySoundOnAnimationEvent : MonoBehaviour
{
    [SerializeField] private AudioClip leftFootstep;
    [SerializeField] private AudioClip rightFootstep;

    private AudioSource audioSource;
    private bool isLeftFootstep;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (isLeftFootstep)
        {
            audioSource.PlayOneShot(leftFootstep);

            isLeftFootstep = false;
        }
        else
        {
            audioSource.PlayOneShot(rightFootstep);

            isLeftFootstep = true;
        }
    }
}
