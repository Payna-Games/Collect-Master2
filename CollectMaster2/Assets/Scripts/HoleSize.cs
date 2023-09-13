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
    [SerializeField] private float scaleSpeed;
    private bool increase = false;
    [SerializeField] private Image circle;
    //private Animator animator;
    private CameraSwitcher cameraSwitcher;
    private int cameraindex = 1;
    
    //circle fill değerleri
    private float scaleValue;
    private float scaleValue2;
    private float circleRatio;
    public float fillSpeed = 0.5f;
    private float smoothfillAmount;

    private void Start()
    {

        cameraSwitcher = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
        //animator = GetComponent<Animator>();
    }

    private void IncreaseScale()
    {
        increase = true;

    }

    
    
    public void CollectibleCollected(float objectSize)
    {
        scaleValue = objectSize;
        scaleValue2 +=objectSize;
        circleRatio += scaleValue / scaleIncraseThreshold;
        
        
        if (scaleValue2 >= scaleIncraseThreshold)
        {
            IncreaseScale();
            cameraSwitcher.SwitchCamera(cameraindex);
            cameraindex++;
            scaleValue2 = scaleValue2 % scaleIncraseThreshold;
            circle.fillAmount = 0;
            circleRatio = 0;



        }
        
    }

    private void Update()
    {
        circle.fillAmount = Mathf.Lerp(circle.fillAmount, circleRatio, Time.deltaTime * fillSpeed);

        if (increase)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale *  scaleStep, Time.deltaTime * scaleSpeed);
            increase = false;
        }

    }
}
