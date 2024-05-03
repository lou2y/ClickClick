using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Sound(int sound)
    {
        audioSource.clip = audioClips[sound];
        audioSource.Play();
    }

    private void Start()
    {
        SoundManager.Instance.Sound(0);
    }

}
