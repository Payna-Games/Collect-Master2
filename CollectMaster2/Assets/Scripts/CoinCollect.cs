using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTime;
    private Color textColor;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        
    }
   
    public static CoinCollect Create(Vector3 position , int coinAmount )
    {
        Transform coinCollectTransform = Instantiate(GameAssets.i.collectedCoinPrefab, position, Quaternion.Euler(45,0,0));
       
        CoinCollect coinCollect = coinCollectTransform.GetComponent<CoinCollect>();
        coinCollect.Setup(coinAmount);
        return coinCollect;
    }

   

    

    public void Setup(int coinAmount)
    {
        textMesh.SetText("+" + coinAmount.ToString());
        textColor = textMesh.color;
        disappearTime = 0.4f;
    }

    private void Update()
    {
        float moveYspeed = 3f;
        transform.position += new Vector3(0, moveYspeed) * Time.deltaTime;

        disappearTime -= Time.deltaTime;
        if (disappearTime < 0)
        {
            float disappearSpeed = 1f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
