using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private HoleSize holeSize;
    [SerializeField] private Transform holeTransform;
    [SerializeField] private GameManager gameManager;
    
     public int objCount = 0;
    [SerializeField] public int objCountLimit;

    
    //[SerializeField] private Animator coinCollectAnimator;
    public GameData gameData;


    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectible collectible))
        {
            Vibrator.Vibrate(50);
            holeSize.CollectibleCollected(collectible.GetSize());
            gameData.coin += collectible.GetCoin();
            gameManager.Coin();
                Destroy(other.gameObject);
                CoinCollect.Create(holeTransform.position, collectible.GetCoin()+gameData.increaseCoin);
                objCount++;

                if (objCount<=objCountLimit)
                {
                    gameData.collectedObjects.Add(collectible.objName);
                }

                

        }
    }
}
