using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class SnapshotTrigger : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float crossfade;
    
    private void OnTriggerEnter(Collider other)
    {
        snapshot.TransitionTo(crossfade);
    }
}
