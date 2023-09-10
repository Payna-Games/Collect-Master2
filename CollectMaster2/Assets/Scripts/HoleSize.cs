using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSize : MonoBehaviour
{
    public void CollectibleCollected(float objectSize)
    {
        Debug.Log("increase the size by " + objectSize);
    }
}
