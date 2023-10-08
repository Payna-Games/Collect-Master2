using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HoleSize : MonoBehaviour
{
    [SerializeField] private float scaleIncraseThreshold;
    [SerializeField] public float scaleStep;
    [SerializeField] private float scaleSpeed;
    [SerializeField] private Image circle;
    public GameData gameData;
    public Vector3[] targetSize;
    public int currentSizeIndex = 0;
    public static Transform holeLocal;
    private CameraSwitcher cameraSwitcher;
    [SerializeField] private TextMeshProUGUI wowText;
    [SerializeField] private GameObject buttons;


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
     private PlayerController playerController;
     private int i;
     private string[] messages = { "GREAT!", "SUPER!", "INCREDIBLE!", "WOAAAH FASTERR!" };
    private void Start()
    {
        
        cameraSwitcher = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
        playerController = GetComponent<PlayerController>();
        i = 0;
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
            cameraSwitcher.SwitchCamera(currentSizeIndex+1);
            
            scaleValue2 = scaleValue2 % scaleIncraseThreshold;
            circle.fillAmount = 0;
            circleRatio = 0;
           
            

        }
        
    }

    private void Update()
    {
        if (!gameManager.holeSizeStop)
        {
            circle.fillAmount = Mathf.Lerp(circle.fillAmount, circleRatio, Time.deltaTime * fillSpeed);
       

        

            if (increase && !hasIncreased)
            {
                transform.localScale += holeSizeSpeed * Vector3.one * Time.deltaTime;
         
          


            }
            
            if (currentSizeIndex == 5)
            {
                gameManager.holeSizeStop = true;
            }
            
            if (transform.localScale.x >= targetSize[ currentSizeIndex+1].x && transform.localScale.y >= targetSize[ currentSizeIndex+1].y && transform.localScale.z >= targetSize[ currentSizeIndex+1].z)
            {
           
                if (currentSizeIndex <= 3 && !buttons.gameObject.activeSelf)
                {
                    currentSizeIndex++;
                    StartCoroutine(MoveSpeedIncrease());
                    
                }
                hasIncreased = true;
               


            }

            
        }
        
        
          

       
    }

    private IEnumerator MoveSpeedIncrease()
    {
        

        if (i<=2) 
        
        { 
            wowText.gameObject.SetActive(true); 
            wowText.text = messages[i].ToString(); 
            yield return new WaitForSeconds(3f);
        }

        if (i == 3)
        {
            wowText.gameObject.SetActive(true); 
            wowText.text = messages[i].ToString(); 
            playerController._moveSpeed = 0.027f;
            yield return new WaitForSeconds(5f);
            playerController._moveSpeed = 0.029f;
        }

        wowText.gameObject.SetActive(false);
        i++;



    }
}
