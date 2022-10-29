using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    //Encapsulation
    private float speedObstacle;
    //Encapsulation
    private AudioSource obstacleAudio;
    public float SpeedObstacle
    {
        get
        {
            return speedObstacle;
        }
        set
        {
            speedObstacle = value;
        }
    }
    void Awake()
    {
        obstacleAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speedObstacle);
    }
    public void PlayObstacleAudio(AudioClip clip)
    {
        obstacleAudio.PlayOneShot(clip,1.0f);
    }
    
}
