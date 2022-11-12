using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSlower : Coins
{
    private int value = 0;
    private int index = 1;
    private float slower = 7.5f;

    void Start()
    {
        CoinPoint = value;
        IndexSound = index;
    }
    //polymorphism
    public override void OnTriggerEnter(Collider other)
    {
        base.SlowerPlayer(slower);
    }
}