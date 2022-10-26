using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private AudioSource enemyAudio;
    public AudioClip bouncyAudio;
    private Rigidbody enemyrb;
    // Start is called before the first frame update
    void Start()
    {
        enemyAudio = GetComponent<AudioSource>();
        //enemyrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //enemyrb.AddForce(Vector3.right * speed);
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        enemyAudio.PlayOneShot(bouncyAudio,1.0F);
    }
}
