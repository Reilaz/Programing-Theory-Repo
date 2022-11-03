using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGood : Coins
{
    private int value = 1;
    private int index = 1;

    void Start() 
    {
        CoinPoint = value;
        IndexSound = index;   
    }
}
    