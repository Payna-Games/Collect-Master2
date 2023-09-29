using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

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
    [SerializeField] private TextMeshProUGUI holeLevelText;
    [SerializeField] private TextMeshProUGUI IncomeLevelText;


    private void Awake()
    {
        cameraSwitcher = GameObject.Find("Cameras").GetComponent<CameraSwitcher>();
       

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
        hole.transform.localScale += holeSize.scaleStep * Vector3.one;
        gameData.holeSizeLevel++;
        holeLevelText.text = "Level: " + gameData.holeSizeLevel.ToString();
        cameraSwitcher.SwitchCamera(holeSize.cameraindex);
        holeSize.cameraindex++;
        Debug.Log(holeSize.cameraindex);

    }
    public void TimeButton()
    {

        gameData.timeDuration += 5;
        gameData.timeLevel++;
        timeLevelText.text ="Level: " + gameData.timeLevel.ToString();
       // PlayerPrefs.SetInt("TimeDuration" ,gameData.timeDuration);


    }
    public void IncomeButton()
    {
        destroyTrigger.increaseCoin++;
        gameData.IncomeLevel++;
        IncomeLevelText.text ="Level: " + gameData.IncomeLevel.ToString();


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
