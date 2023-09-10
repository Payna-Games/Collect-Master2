using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private HoleSize holeSize;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectible collectible))
        {
            holeSize.CollectibleCollected(collectible.GetSize());
                Destroy(other.gameObject);
        }
    }
}
