using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BallThud : MonoBehaviour
{
    public Rigidbody rb;

    public AudioSource audioSource;
    public AudioClip[] thuds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }
    public void PlayThud(float multiplier)
    {
        audioSource.volume = 0.1f * multiplier;
        audioSource.PlayOneShot(thuds[Random.Range(0, thuds.Length - 1)]);
    }
}
