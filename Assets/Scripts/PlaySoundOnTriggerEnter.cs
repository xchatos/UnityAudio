using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySoundOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
    }
}
