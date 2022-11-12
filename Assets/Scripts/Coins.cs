using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //Begin Encapsulation
    private PlayerController playerController;
    private int coinPoint;
    private int indexSound;
    public int CoinPoint
    {
        get{    return coinPoint;   }
        set{    coinPoint = value;  }
    }
    public int IndexSound
    {
        get{    return indexSound;  }
        set{    indexSound = value;  }
    }
    //End Encapsulation
    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            UpdatePlayerScore();
            playerController.PlaySfx(indexSound);
        }
    }
    void UpdatePlayerScore()
    {
        playerController.CounterValue += coinPoint;
    }
    public void SlowerPlayer(float slower)
    {
        playerController.Speed -= slower;
        playerController.SlowerPlayer();
    }
}