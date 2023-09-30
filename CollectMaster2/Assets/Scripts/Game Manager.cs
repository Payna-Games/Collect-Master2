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

    

    public Button incomeButton;
    [SerializeField] private Button holeButton;
    [SerializeField] private Button timeButton;
     private SceneManagement sceneManagement; 
    public  bool holeSizeStop = false;

    





    private void Awake()
    {
        
        cameraSwitcher = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
        sceneManagement = GetComponent<SceneManagement>();
      
        if (!gameData.tryAgain)
        {
            gameData.i = 0;
            gameData.t = 0;
            gameData.h = 0;
            
        }
        if (gameData.i <3)
        {
            incomeCoinText.text = gameData.incomePreis[gameData.i].ToString();
        }
        else if (gameData.i >= 3)
        {
            incomeCoinText.text = "Max";
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
            timeButton.interactable = false;
            timeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);
        }

        if (gameData.scene > 0)
        {
            holeSize.transform.localScale = gameData.holeScale;
        }
        
        

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
    }

    public void HoleSizeButton()
    {
        gameData.h++;
        if (!holeSizeStop)
            hole.transform.localScale += holeSize.scaleStep * Vector3.one;
            gameData.holeSizeLevel++;
            holeLevelText.text = "Level: " + gameData.holeSizeLevel.ToString();
            cameraSwitcher.SwitchCamera(holeSize.cameraindex);
            holeSize.cameraindex++;
        
        
        
        if (gameData.h<5)
        {
            holeCoinText.text = gameData.holePreis[gameData.h].ToString();
        }
        else if (gameData.h >= 5)
        {
            holeCoinText.text = "Max";
            holeButton.interactable = false;
            holeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);
            holeSizeStop = true;
        }

       

    }
    public void TimeButton()
    {
        gameData.t++;
        
        gameData.timeDuration += 5;
        gameData.timeLevel++;
        timeLevelText.text ="Level: " + gameData.timeLevel.ToString();
       //" PlayerPrefs.SetInt("TimeDuration" ,gameData.timeDuration);

       if (gameData.t<5)
       {
           timeCoinText.text = gameData.timePreis[gameData.t].ToString();
       }
       else if (gameData.t >= 5)
       {
           timeCoinText.text = "Max";
           timeButton.interactable = false;
           timeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);

       }

       
    }
    public void IncomeButton()
    {
        gameData. i++;
        destroyTrigger.increaseCoin++;
        gameData.IncomeLevel++;
        IncomeLevelText.text ="Level: " + gameData.IncomeLevel.ToString();
        if (gameData.i<3)
        {
            incomeCoinText.text = gameData.incomePreis[gameData.i].ToString();
        }
        else if (gameData.i >= 3)
        {
            incomeCoinText.text = "Max";
            incomeButton.interactable = false;
            incomeButton.GetComponent<Image>().color = new Color32(0xAA, 0xAA, 0xAA, 0xAA);

        }
        
       



    }

    public void ScreenButton()
    {
        if (!countdownTimer.isCountingDown)
        {
            gameOver = false;
            countdownTimer.isCountingDown = true;
            countdownTimer.StartCountdown();
            
          
        }
    }

    public void Coin()
    {
        gameData.coin += destroyTrigger.increaseCoin;
        coinText.text = gameData.coin.ToString();
    }
    
   
}
