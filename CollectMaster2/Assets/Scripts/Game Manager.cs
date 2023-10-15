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
    
    public TextMeshProUGUI timeLevelText;
    public TextMeshProUGUI timeCoinText;
    
    public TextMeshProUGUI holeLevelText;
    public TextMeshProUGUI holeCoinText;
   
    public TextMeshProUGUI IncomeLevelText;
    public TextMeshProUGUI incomeCoinText;

    

    [SerializeField] Button incomeButton;
    public Button holeButton;
    [SerializeField] private Button timeButton;
     private SceneManagement sceneManagement; 
    
    private Color textColor;


    [SerializeField] private FloatingJoystick floatingJoystick;
    [SerializeField] private GameObject timeImage;
    
    [SerializeField] private Canvas tutorialAnimCanvas;
    [SerializeField] private TextMeshProUGUI collectAll;
    private bool tutorial;

    


    private void Awake()
    {
        
        if (UnityEngine.PlayerPrefs.GetInt("tutorial", 1) == 1)
        {
            
            tutorial = true;
        
            UnityEngine.PlayerPrefs.SetInt("tutorial", 0);
        }
        else
        {
            tutorial = false;
            collectAll.gameObject.SetActive(false);
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
        if (gameData.h <6)
        {
            holeCoinText.text = gameData.holePreis[gameData.h].ToString();
        }
        else if (gameData.h >= 6)
        {
            holeCoinText.text= "Max";
            holeCoinText.alpha= 0.7f;
            holeLevelText.alpha = 0.7f;
            holeCoinText.color = new Color(0, 0, 0, 0.7f);
            holeButton.interactable = false;
            holeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);
            sceneManagement.holeSizeStop = true;
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
            
            sceneManagement.SaveData();
           
            if (!sceneManagement.holeSizeStop)
            {
                hole.transform.localScale = holeSize.targetSize[gameData.currentSizeIndex];
                gameData.holeSizeLevel++;
                holeLevelText.text = "Level: " + gameData.holeSizeLevel.ToString();
                cameraSwitcher.SwitchCamera( gameData.currentSizeIndex);

            
            }
           
        
        
        
            if (gameData.h<6)
            {
                holeCoinText.text = gameData.holePreis[gameData.h].ToString();
            }
            else if (gameData.h >= 6)
            {
                holeCoinText.text = "Max";
                holeCoinText.alpha= 0.7f;
                holeLevelText.alpha = 0.7f;
                holeButton.interactable = false;
                holeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);
                sceneManagement.holeSizeStop = true;
            } 
          
        }
        


    }
    public void TimeButton()
    {
        if (gameData.coin >= gameData.timePreis[gameData.t])
        {
            

            if (gameData.t<=3)
            {
                
                gameData.coin -= gameData.timePreis[gameData.t];
                coinText.text = gameData.coin.ToString();
                gameData.t++;
            
        
                gameData.timeDuration += 5;
                gameData.timeSave += 5;
                gameData.timeLevel++;
                timeLevelText.text ="Level: " + gameData.timeLevel.ToString();
           
                sceneManagement.SaveData();
                timeCoinText.text = gameData.timePreis[gameData.t].ToString();
                
            }
            else if (gameData.t == 4)
            {
                gameData.coin -= gameData.timePreis[gameData.t];
                coinText.text = gameData.coin.ToString();
                gameData.t++;
            
        
                gameData.timeDuration += 10;
                gameData.timeSave += 10;
                gameData.timeLevel++;
                timeLevelText.text ="Level: " + gameData.timeLevel.ToString();
           
                sceneManagement.SaveData();
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
            sceneManagement.SaveData();
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
            tutorialAnimCanvas.gameObject.SetActive(false);
            timeImage.gameObject.SetActive(true);
            countdownTimer.isCountingDown = true;
            countdownTimer.StartCountdown();
            
          
        }
        sceneManagement.SaveData();
    }

    public void Coin()
    {
        gameData.coin += gameData.increaseCoin;
        coinText.text = gameData.coin.ToString();
        sceneManagement.SaveData();
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



         if (gameData.coin <  gameData.timePreis[gameData.t] && gameData.t<6 )
        {
            timeButton.image.color= new Color32(0x5A, 0x5A, 0x5A, 0xFF);
        }
         
         else if(gameData.coin >=  gameData.timePreis[gameData.t] && gameData.t<6)
         {
             timeButton.image.color= new Color32(0xFF, 0xFF, 0xFF, 0xFF);
         }
         
         if (gameData.coin < gameData.holePreis[gameData.h]&&gameData.h<6)
        {
            holeButton.image.color = new Color32(0x5A, 0x5A, 0x5A, 0xFF);
        }
        
         else if(gameData.coin >= gameData.holePreis[gameData.h]&&gameData.h<6)
         {
             holeButton.image.color = new Color32(0xFF, 0xFF, 0xFF, 0xFF);

         }
    }
    
   
}
