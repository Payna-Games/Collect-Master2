using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleSize : MonoBehaviour
{
    [SerializeField] private float scaleIncraseThreshold;
    [SerializeField] private float scaleStep;
    private float scaleValue;
    

    private void IncreaseScale()
    {
        transform.localScale += scaleStep * Vector3.one;
        
    }
    
    public void CollectibleCollected(float objectSize)
    {
        scaleValue += objectSize;
        if (scaleValue >= scaleIncraseThreshold)
        {
            IncreaseScale();
            scaleValue = scaleValue % scaleIncraseThreshold;
        }
        Debug.Log("increase the size by " + objectSize);
    }
}
