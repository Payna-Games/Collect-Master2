using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HoleSize : MonoBehaviour
{
    [SerializeField] private float scaleIncraseThreshold;
    [SerializeField] private float scaleStep;
    [SerializeField] private Image circle;
    private float scaleValue;
    private float circleRatio;
    

    private void IncreaseScale()
    {
        transform.localScale += scaleStep * Vector3.one;
        
    }
    
    public void CollectibleCollected(float objectSize)
    {
        scaleValue += objectSize;
        circleRatio = scaleValue / scaleIncraseThreshold;
        circle.fillAmount += circleRatio;
        if (scaleValue >= scaleIncraseThreshold)
        {
            IncreaseScale();
            scaleValue = scaleValue % scaleIncraseThreshold;
            circle.fillAmount = 0;

        }
        
    }
}
