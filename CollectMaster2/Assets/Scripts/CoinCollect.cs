using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    public static CoinCollect Create(Vector3 position , int coinAmount )
    {
        Transform coinCollectTransform = Instantiate(GameAssets.i.collectedCoinPrefab, position, Quaternion.Euler(45,0,0));
       
        CoinCollect coinCollect = coinCollectTransform.GetComponent<CoinCollect>();
        coinCollect.Setup(coinAmount);
        return coinCollect;
    }

    private TextMeshPro textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        
    }

    public void Setup(int coinAmount)
    {
        textMesh.SetText(coinAmount.ToString());
    }
}
