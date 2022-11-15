using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Begin Encapsulation
    private AudioSource coinAudio;
    [SerializeField] private AudioClip goodClip;
    [SerializeField] private AudioClip badClip;
    [SerializeField] private ParticleSystem goodParticle;
    [SerializeField] private ParticleSystem badParticle;
    [SerializeField] private List<ParticleSystem> explosions;
    [SerializeField] private List<AudioClip> sounds;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float xRange = 11;
    [SerializeField] private int counterValue = 0;
    public int CounterValue
    {
        get{    return counterValue;    }
        set{    counterValue = value;   }
    }
    public float Speed
    {
        get{    return speed;   }
        set
        {
            if (value > 1)
            {
                speed = value;
            }
        }
    }
    //End Encapsulation
    void Start()
    {
        coinAudio = GetComponent<AudioSource>();
        InitList();
    }
    void Update()
    {
        ControlMovement();
    }
    private void ControlMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

        float xPos = Mathf.Clamp(transform.position.x,-xRange,xRange);
        transform.position = new Vector3(xPos,transform.position.y,transform.position.z);
    }
    void InitList()
    {
        explosions.Add(badParticle);
        explosions.Add(goodParticle);
        sounds.Add(badClip);
        sounds.Add(goodClip);
    }
    public void PlaySfx(int index)
    {
        coinAudio.PlayOneShot(sounds[index],1.0f);
        explosions[index].Play();
    }
    public void SlowerPlayer()
    {
        StartCoroutine(SlowerTimer());
    }
    IEnumerator SlowerTimer()
    {
        yield return new WaitForSeconds(2.0f);
        Speed = 10.0f;
    }
}