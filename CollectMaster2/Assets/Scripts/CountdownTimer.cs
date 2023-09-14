using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    //public int countdownDuration = 10; // Başlangıç süresi (saniye)
    private int currentTime;
    private GameManager gameManager;
    public GameData gameData;
    public bool isCountingDown = false;
    

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        //currentTime = gameData.countdownTimer;
        countdownText.text = "00:" + gameData.timeDuration.ToString();
        UpdateUI();
       

        
    }

    public void CountDown()
    {
        countdownText.text = "00:" +gameData.timeDuration.ToString();
    }
    public void StartCountdown()
    {
        InvokeRepeating("UpdateCountdown", 1.0f, 1.0f); 
    }

    private void UpdateCountdown()
    {
        
        if (gameData.timeDuration > 0)
        {
            gameData.timeDuration -= 1; 
            UpdateUI();

            if (gameData.timeDuration == 0)
            {
                
            }
        }
       
    }

  

    private void UpdateUI()
    {
        
        // Geri sayım metnini güncelle
        countdownText.text = "00:" +gameData.timeDuration.ToString();
    }

    private void Update()
    {
        if (isCountingDown)
        {
            StartCountdown();
            isCountingDown = false;
        }
    }
}
