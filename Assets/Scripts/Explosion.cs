using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource source;
    public List<AudioClip> audios = new List<AudioClip>();
    int sound;

    void Start()
    {
        sound = Random.Range(0, audios.Count);
        source.clip = audios[sound];
        source.Play();        
    }
}
