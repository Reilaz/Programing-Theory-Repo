using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inheritance
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
    