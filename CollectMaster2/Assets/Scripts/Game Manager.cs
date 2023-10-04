using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    private GameObject buttons;
    private GameObject hole;
    [SerializeField] private HoleSize holeSize;
    [SerializeField] private DestroyTrigger destroyTrigger;
    private CameraSwitcher cameraSwitcher;
    
    
    private CountdownTimer countdownTimer;
    public GameData gameData;
    public TextMeshProUGUI coinText;
    
    [SerializeField] private TextMeshProUGUI timeLevelText;
    [SerializeField] private TextMeshProUGUI timeCoinText;
    
    [SerializeField] private TextMeshProUGUI holeLevelText;
    [SerializeField] private TextMeshProUGUI holeCoinText;
   
    [SerializeField] private TextMeshProUGUI IncomeLevelText;
    [SerializeField] private TextMeshProUGUI incomeCoinText;

    

    [SerializeField] Button incomeButton;
    [SerializeField] private Button holeButton;
    [SerializeField] private Button timeButton;
     private SceneManagement sceneManagement; 
    public  bool holeSizeStop = false;
    private Color textColor;
    
    private bool tutorial;
    
    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private Canvas tutorialAnimCanvas;
    [SerializeField] private GameObject timeImage;
    
    




    private void Awake()
    {
        if (PlayerPrefs.GetInt("tutorial", 1) == 1)
        {
            
            tutorial = true;

            PlayerPrefs.SetInt("tutorial", 0);
        }
        else
        {
            tutorial = false;
            tutorialAnimCanvas.gameObject.SetActive(false);
        }
        
        cameraSwitcher = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
        sceneManagement = GetComponent<SceneManagement>();
        

        if (gameData.i <3)
        {
            incomeCoinText.text = gameData.incomePreis[gameData.i].ToString();
        }
        else if (gameData.i >= 3)
        {
            incomeCoinText.text = "Max";
            incomeCoinText.alpha= 0.7f;
            IncomeLevelText.alpha = 0.7f;
           
            incomeButton.interactable = false;
            incomeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);
        }
        if (gameData.h <5)
        {
            holeCoinText.text = gameData.holePreis[gameData.h].ToString();
        }
        else if (gameData.h >= 5)
        {
            holeCoinText.text= "Max";
            holeCoinText.alpha= 0.7f;
            holeLevelText.alpha = 0.7f;
            holeCoinText.color = new Color(0, 0, 0, 0.7f);
            holeButton.interactable = false;
            holeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);
            holeSizeStop = true;
        }
        
        if (gameData.t <5)
        {
            timeCoinText.text = gameData.timePreis[gameData.t].ToString();
            
        }
        else if (gameData.t >= 5)
        {
            timeCoinText.text = "Max";
            timeCoinText.alpha= 0.7f;
            timeLevelText.alpha = 0.7f;
            timeCoinText.color = new Color(0, 0, 0, 0.7f);
            timeButton.interactable = false;
            timeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);
           
        }

        holeSize.currentSizeIndex = gameData.currentSizeIndex;
        cameraSwitcher.SwitchCamera(gameData.currentSizeIndex);
        Debug.Log("hole leveli = "+gameData.currentSizeIndex);
        Debug.Log( holeSize.currentSizeIndex+1 +".kamera");

    }

    void Start()
    {
        gameOver = true;
        buttons = GameObject.Find("Buttons");
        hole = GameObject.Find("HoleParent");
        countdownTimer = GetComponent<CountdownTimer>();
        holeLevelText.text = "Level: " + gameData.holeSizeLevel.ToString();
        timeLevelText.text ="Level: " + gameData.timeLevel.ToString();
        IncomeLevelText.text ="Level: " + gameData.IncomeLevel.ToString();
        coinText.text = gameData.coin.ToString();

        
            hole.transform.localScale = holeSize.targetSize[gameData.currentSizeIndex];
        

        

    }

    public void HoleSizeButton()
    {

        if (gameData.coin >= gameData.holePreis[gameData.h])
        {
            gameData.coin -= gameData.holePreis[gameData.h];
            coinText.text = gameData.coin.ToString();
            
            gameData.h++;
            gameData.currentSizeIndex++;
            
            
           
            if (!holeSizeStop)
            {
                hole.transform.localScale = holeSize.targetSize[gameData.currentSizeIndex];
                gameData.holeSizeLevel++;
                holeLevelText.text = "Level: " + gameData.holeSizeLevel.ToString();
                cameraSwitcher.SwitchCamera( gameData.currentSizeIndex+1);

            
            }
           
        
        
        
            if (gameData.h<5)
            {
                holeCoinText.text = gameData.holePreis[gameData.h].ToString();
            }
            else if (gameData.h >= 5)
            {
                holeCoinText.text = "Max";
                holeCoinText.alpha= 0.7f;
                holeLevelText.alpha = 0.7f;
                holeButton.interactable = false;
                holeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);
                holeSizeStop = true;
            } 

        }
        
            
                
        
       
       

    }
    public void TimeButton()
    {
        if (gameData.coin >= gameData.timePreis[gameData.t])
        {
            gameData.coin -= gameData.timePreis[gameData.t];
            coinText.text = gameData.coin.ToString();
            gameData.t++;
           
        
            gameData.timeDuration += 5;
            CountdownTimer.time += 5;
            gameData.timeLevel++;
            timeLevelText.text ="Level: " + gameData.timeLevel.ToString();
       

            if (gameData.t<5)
            {
                timeCoinText.text = gameData.timePreis[gameData.t].ToString();
            }
            else if (gameData.t >= 5)
            {
                timeCoinText.text = "Max";
                timeCoinText.alpha= 0.7f;
                timeLevelText.alpha = 0.7f;
                timeButton.interactable = false;
                timeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);

            } 
        }
       
        
        

       
    }
    public void IncomeButton()
    {
        if (gameData.coin >= gameData.incomePreis[gameData.i])
        {
            gameData.coin -= gameData.incomePreis[gameData.i];
            coinText.text = gameData.coin.ToString();
           
            gameData.i++;
            gameData.increaseCoin++;
            gameData.IncomeLevel++;
            IncomeLevelText.text ="Level: " + gameData.IncomeLevel.ToString();
            if (gameData.i<3)
            {
                incomeCoinText.text = gameData.incomePreis[gameData.i].ToString();
            }
            else if (gameData.i >= 3)
            {
                incomeCoinText.text = "Max";
                incomeCoinText.alpha= 0.7f;
                IncomeLevelText.alpha = 0.7f;
                incomeButton.interactable = false;
                incomeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);

            }

        }
       


    }

    public void ScreenButton()
    {
        if (!countdownTimer.isCountingDown)
        {
            gameOver = false;
            tutorialAnimCanvas.gameObject.SetActive(false);
            timeImage.gameObject.SetActive(true);
            countdownTimer.isCountingDown = true;
            countdownTimer.StartCountdown();
            
          
        }
    }

    public void Coin()
    {
        gameData.coin += gameData.increaseCoin;
        coinText.text = gameData.coin.ToString();
    }

    private void Update()
    {
         if (gameData.coin < gameData.incomePreis[gameData.i] && gameData.i<3 )
        {
            incomeButton.image.color = new Color32(0x5A, 0x5A, 0x5A, 0xFF);
            
            
        }
         else if (gameData.coin >= gameData.incomePreis[gameData.i] && gameData.i < 3)
         {
             incomeButton.image.color = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
         }



         if (gameData.coin <  gameData.timePreis[gameData.t] && gameData.t<5 )
        {
            timeButton.image.color= new Color32(0x5A, 0x5A, 0x5A, 0xFF);
        }
         
         else if(gameData.coin >=  gameData.timePreis[gameData.t] && gameData.t<5)
         {
             timeButton.image.color= new Color32(0xFF, 0xFF, 0xFF, 0xFF);
         }
         
         if (gameData.coin < gameData.holePreis[gameData.h]&&gameData.h<5)
        {
            holeButton.image.color = new Color32(0x5A, 0x5A, 0x5A, 0xFF);
        }
        
         else if(gameData.coin >= gameData.holePreis[gameData.h]&&gameData.h<5)
         {
             holeButton.image.color = new Color32(0xFF, 0xFF, 0xFF, 0xFF);

         }
    }
    
   
}
