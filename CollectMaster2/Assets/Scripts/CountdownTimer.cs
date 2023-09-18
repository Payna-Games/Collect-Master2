using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    [SerializeField] private Image timeImage;

    private Animator timeImageAnimator;
    //public int countdownDuration = 10; // Başlangıç süresi (saniye)
    private int currentTime;
    private GameManager gameManager;
    public GameData gameData;
    public bool isCountingDown;
    

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        //currentTime = gameData.countdownTimer;
        countdownText.text = "00:" + gameData.timeDuration.ToString();
        UpdateUI();
        timeImageAnimator = GameObject.Find("TimeImage").GetComponent<Animator>();


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

            if (gameData.timeDuration == 5)
            {
                timeImageAnimator.Play("TimeHurryUp");
                timeImage.color = new Color(1f, 0, 0, 1);
                
            }
            if (gameData.timeDuration == 0)
            {
                timeImageAnimator.enabled = false;
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
       
    }
}
