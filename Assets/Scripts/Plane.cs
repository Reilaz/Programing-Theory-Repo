using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public ParticleSystem explosionBall;
    private AudioSource planeAudio;
    public AudioClip destroyAudio;
    // Start is called before the first frame update
    void Start()
    {
        planeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        explosionBall.transform.position = new Vector3(collision.transform.position.x,collision.transform.position.y,collision.transform.position.z);
        explosionBall.Play();
        planeAudio.PlayOneShot(destroyAudio,1.0f);
        collision.gameObject.SetActive(false);
    }
}
