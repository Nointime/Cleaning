using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    private AudioSource audioS;
    [SerializeField] private AudioClip[] audioClips;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    public void AudioStart(int a)
    {
        audioS.clip = audioClips[a];
        audioS.Play();
    }
}
