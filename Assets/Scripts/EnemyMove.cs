using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inheritance
public class EnemyMove : ObstacleController
{
    private float speed = 10.0f;
    public AudioClip bouncyAudio;

    void Start()
    {
        SpeedObstacle = speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayObstacleAudio(bouncyAudio);
    }
}
