using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
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
}
