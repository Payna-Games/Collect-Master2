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
    [SerializeField] private SceneManagement sceneManagement;
    private bool wowTextWait;
    private bool moveSpeedIncrease;


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
    [SerializeField] private int m;
     private string[] messages = { "GREAT!", "SUPER!", "INCREDIBLE!", "WOAAAH FASTERR!" };
    private void Start()
    {
        
        cameraSwitcher = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
        playerController = GetComponent<PlayerController>();
        m = 0;
        wowTextWait = false;
        moveSpeedIncrease = true;
    }

  
    
    public void CollectibleCollected(float objectSize)
    {
        scaleValue = objectSize;
        scaleValue2 +=objectSize;
        circleRatio += scaleValue / scaleIncraseThreshold;
        
        
        if (scaleValue2 >= scaleIncraseThreshold && !sceneManagement.holeSizeStop)
        {
            increase = true;
            hasIncreased = false;
            cameraSwitcher.SwitchCamera(currentSizeIndex+1);
            moveSpeedIncrease = false;
            
            scaleValue2 = scaleValue2 % scaleIncraseThreshold;
            circle.fillAmount = 0;
            circleRatio = 0;
           
            

        }
        
    }

    private void Update()
    {
        if (UnityEngine.PlayerPrefs.GetInt("holeSizeStop") == 1)
        {
            sceneManagement.holeSizeStop = true;
            
        
            
        }
        else
        {
            sceneManagement.holeSizeStop = false;
            
        }
        if (!sceneManagement.holeSizeStop && !wowTextWait)
        {
            circle.fillAmount = Mathf.Lerp(circle.fillAmount, circleRatio, Time.deltaTime * fillSpeed);
       

        

            if (increase && !hasIncreased)
            {
                transform.localScale += holeSizeSpeed * Vector3.one * Time.deltaTime;
         
          


            }
            
            if (currentSizeIndex == 6)
            {
                
               sceneManagement.holeSizeStopSave = 1;
               sceneManagement.HoleStopSave();
                hasIncreased = true;

            }
            
            if (transform.localScale.x >= targetSize[ currentSizeIndex+1].x && transform.localScale.y >= targetSize[ currentSizeIndex+1].y && transform.localScale.z >= targetSize[ currentSizeIndex+1].z)
            {
           
                if (currentSizeIndex <=5 && CountdownTimer.timerStart == true && m <=3 && !wowTextWait && !moveSpeedIncrease)
                {
                    currentSizeIndex++;
                    StartCoroutine(MoveSpeedIncrease());
                    moveSpeedIncrease = true;

                }
                if (currentSizeIndex >5 && CountdownTimer.timerStart == true && m <=3 && !wowTextWait && !moveSpeedIncrease)
                {
                    StartCoroutine(MoveSpeedIncrease());
                    moveSpeedIncrease = true;
                }
                
                
                 
                hasIncreased = true;
                sceneManagement.SaveData();

            }

            if (hasIncreased && CountdownTimer.timerStart == true && m <= 3 && !wowTextWait && !moveSpeedIncrease)
            {
                StartCoroutine(MoveSpeedIncrease());
                moveSpeedIncrease = true;
            }
            
         
            
        }
        
        
          

       
    }

    private IEnumerator MoveSpeedIncrease()
    {

        if (!wowTextWait)
        {
            if (m<=2) 
        
            { 
                wowText.gameObject.SetActive(true); 
                wowText.text = messages[m].ToString(); 
                yield return new WaitForSeconds(3f);
            }

            if (m == 3)
            {
                wowTextWait = true;
                
               wowText.gameObject.SetActive(true); 
                wowText.text = messages[m].ToString(); 
                playerController._moveSpeed = 0.040f;
                yield return new WaitForSeconds(5f);
                playerController._moveSpeed = 0.028f;
                m = -1;
                wowTextWait = false;
                

            }

            wowText.gameObject.SetActive(false);
            m++;
            Debug.Log("m"+m);
            
        }
       



    }
}
