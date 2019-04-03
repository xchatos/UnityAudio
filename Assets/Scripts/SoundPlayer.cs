using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundPlayer : MonoBehaviour
{
    #region Private Variables
    private enum AudioMethods { Reset, Play, PlayDelayed, PlayOneshot, PlayClipAtPoint, PlayScheduled, Stop, Pause, UnPause };
    private AudioSource audioSource;

    private bool oneshotDone = false;
    private bool playClipAtPointDone = false;
    #endregion

    [SerializeField] private AudioMethods audioMethods;
    [SerializeField] AudioClip audioClip;
    [SerializeField] Vector3 clipPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioMethods = AudioMethods.Reset;
    }

    void Update()
    {
        // Plays the audio clip that is set to play (either from the AudioSource component or code). 
        // Can be stopped or paused.
        if (audioMethods == AudioMethods.Play)
        {
            Play();
        }

        // Plays the audio clip with an initial delay that can be set.
        else if (audioMethods == AudioMethods.PlayDelayed)
        {
            PlayDelayed();
        }

        // Plays a designated audio clip all the way to the end. Using PlayOneshot, 
        // you can play multiple sounds by using only one AudioSource.
        else if (audioMethods == AudioMethods.PlayOneshot)
        {
            if (!oneshotDone)
            {
                PlayOneshot();
            }
            else
            {
                return;
            }

        }

        // Creates an empty game object in the world space position you set and plays the designated audio clip.
        else if (audioMethods == AudioMethods.PlayClipAtPoint)
        {
            if (!playClipAtPointDone)
            {
                PlayClipAtPoint();
            }
            else
            {
                return;
            }
        }

        // PlayScheduled is often used for music players since it is completely framerate independent. 
        // With this method, you can e.g. seamlessly alternate between two music tracks as long as 
        // they are at the same tempo and have an equal amount of bars.
        else if (audioMethods == AudioMethods.PlayScheduled)
        {
            PlayScheduled();
        }

        // Stops the audio clip.
        else if (audioMethods == AudioMethods.Stop)
        {
            Stop();
        }

        // Pauses the audio clip.
        else if (audioMethods == AudioMethods.Pause)
        {
            Pause();
        }

        // Unpauses the audio clip.
        else if (audioMethods == AudioMethods.UnPause)
        {
            Unpause();
        }

        else if (audioMethods == AudioMethods.Reset)
        {
            Reset();
        }
    }

    public void Play()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PlayDelayed()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayDelayed(2f);
        }
    }

    public void PlayOneshot()
    {
        audioSource.PlayOneShot(audioClip);
        oneshotDone = true;
    }

    public void PlayClipAtPoint()
    {
        AudioSource.PlayClipAtPoint(audioClip, clipPosition);
        playClipAtPointDone = true;
    }

    public void PlayScheduled()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayScheduled(1);
        }
    }

    public void Stop()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void Pause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void Unpause()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.UnPause();
        }
    }

    public void Reset()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
