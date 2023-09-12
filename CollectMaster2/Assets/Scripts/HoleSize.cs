using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class HoleSize : MonoBehaviour
{
    [SerializeField] private float scaleIncraseThreshold;
    [SerializeField] private float scaleStep;
    [SerializeField] private Image circle;
    private CameraSwitcher cameraSwitcher;
    private int cameraindex = 1;
    
    private float scaleValue;
    private float scaleValue2;
    private float circleRatio;

    private void Start()
    {

        cameraSwitcher = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
    }

    private void IncreaseScale()
    {
        transform.localScale += scaleStep * Vector3.one;
        
    }
    
    public void CollectibleCollected(float objectSize)
    {
        scaleValue = objectSize;
        scaleValue2 +=objectSize;
        circleRatio = scaleValue / scaleIncraseThreshold;
        circle.fillAmount += circleRatio;
       
        if (scaleValue2 >= scaleIncraseThreshold)
        {
            IncreaseScale();
            cameraSwitcher.SwitchCamera(cameraindex);
            cameraindex++;
            scaleValue2 = scaleValue2 % scaleIncraseThreshold;
            circle.fillAmount = 0;
            


        }
        
    }
}
