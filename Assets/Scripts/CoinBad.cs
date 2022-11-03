using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBad : Coins
{
    private int value = -1;
    private int index = 0;

    void Start() 
    {
        CoinPoint = value;
        IndexSound = index;
    }
}
