using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    [Header(" Settings ")] 
    [SerializeField] private int size;

    

    public string name;

    public int coin;

    private void Start()
    {
        GetComponent<Rigidbody>().sleepThreshold = 0;
    }

    public int GetSize()
    {
        return size;
    }

    public int GetCoin()
    {
        return coin;
    }

    public string Name()
    {
        return name;
    }
    
}
