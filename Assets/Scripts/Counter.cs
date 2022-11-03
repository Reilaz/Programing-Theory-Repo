using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip audioBallGood;
    public AudioClip audioBallBad;

    public ParticleSystem explosionGood;
    public ParticleSystem explosionBad;

    public Text CounterText;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
        playerAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CounterText.text = "Count : " + Count;
        other.gameObject.SetActive(false);

        if(other.gameObject.CompareTag("Ball-Good") )
        {
            playerAudio.PlayOneShot(audioBallGood,1.0f);
            explosionGood.Play();
            Count += 1;
            CounterText.text = "Count : " + Count;
        }
        if(other.gameObject.CompareTag("Ball-Bad"))
        {
            playerAudio.PlayOneShot(audioBallBad,1.0f);
            explosionBad.Play();
            Count -= 1;
            CounterText.text = "Count : " + Count;
        }
    }
}
