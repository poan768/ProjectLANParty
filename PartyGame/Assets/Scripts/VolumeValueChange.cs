using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{
    private AudioSource audioSrc;
    private float bgmVolum = 1f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSrc.volume = bgmVolum;
    }

    public void SetVolume(float vol)
    {
        bgmVolum = vol;
    }
}
