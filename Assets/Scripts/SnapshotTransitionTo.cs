using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SnapshotTransitionTo : MonoBehaviour
{
    public AudioMixer main;
    public AudioMixerSnapshot[] Snapshots;
    public float[] weights;
    public float transitionTime;
    private float[] setWeights;

    private void Start()
    {
        setWeights = new float[weights.Length];
    }

    private void OnTriggerEnter(Collider other)
    {
        weights.CopyTo(setWeights, 0);
        main.TransitionToSnapshots(Snapshots,setWeights, transitionTime);
    }

    private void OnTriggerExit(Collider other)
    { 
        setWeights[0] = 1;
        setWeights[1] = 0;
        main.TransitionToSnapshots(Snapshots,setWeights, transitionTime);
    }
}
