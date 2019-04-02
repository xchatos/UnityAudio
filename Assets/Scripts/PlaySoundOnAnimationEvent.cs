using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySoundOnAnimationEvent : MonoBehaviour
{
    #region Private Variables
    private AudioSource audioSource;
    private bool isLeftFootstep;
    #endregion

    [SerializeField] private AudioClip leftFootstep;
    [SerializeField] private AudioClip rightFootstep;

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
