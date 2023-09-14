using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private HoleSize holeSize;
    [SerializeField] private GameManager gameManager;
    public GameData gameData;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectible collectible))
        {
            holeSize.CollectibleCollected(collectible.GetSize());
            gameData.coin += collectible.GetCoin();
            gameManager.Coin();
                Destroy(other.gameObject);
                gameData.collectedObjects.Add(collectible.name);
                
        }
    }
}
