using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class HoleSize : MonoBehaviour
{
    [SerializeField] private float scaleIncraseThreshold;
    [SerializeField] public float scaleStep;
    [SerializeField] private float scaleSpeed;
    [SerializeField] private Image circle;
    public GameData gameData;
    [SerializeField] private Vector3[] targetSize;
    
    [SerializeField] private int currentSizeIndex = 0;
    
    
    private CameraSwitcher cameraSwitcher;
    public int cameraindex = 1;
    
    //circle fill değerleri
    private float scaleValue;
    private float scaleValue2;
    private float circleRatio;
    public float fillSpeed = 0.5f;
    public float holeSizeSpeed = 1;
    private float smoothfillAmount;

    private bool increase = false;
    private bool hasIncreased = false;

    [SerializeField] private GameManager gameManager;
    private void Start()
    {

        cameraSwitcher = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
        gameData.holeScale = transform.localScale;
        
    }

  
    
    public void CollectibleCollected(float objectSize)
    {
        scaleValue = objectSize;
        scaleValue2 +=objectSize;
        circleRatio += scaleValue / scaleIncraseThreshold;
        
        
        if (scaleValue2 >= scaleIncraseThreshold && !gameManager.holeSizeStop)
        {
            increase = true;
            hasIncreased = false;
            
            cameraSwitcher.SwitchCamera(cameraindex);
            cameraindex++;
            scaleValue2 = scaleValue2 % scaleIncraseThreshold;
            circle.fillAmount = 0;
            circleRatio = 0;

            Debug.Log(cameraindex);

        }
        
    }

    private void Update()
    {
        if (!gameManager.holeSizeStop)
        {
            circle.fillAmount = Mathf.Lerp(circle.fillAmount, circleRatio, Time.deltaTime * fillSpeed);
        }

        

       if (increase && !hasIncreased && !gameManager.holeSizeStop)
       {
           transform.localScale += holeSizeSpeed * Vector3.one * Time.deltaTime;
        
          


       }
       if (transform.localScale.x >= targetSize[ currentSizeIndex].x && transform.localScale.y >= targetSize[ currentSizeIndex].y && transform.localScale.z >= targetSize[ currentSizeIndex].z)
       {
           
           if (currentSizeIndex < 3)
           {
               currentSizeIndex++;
               
           }
           hasIncreased = true;
           gameData.holeScale = transform.localScale;
       }

       
    }
}
