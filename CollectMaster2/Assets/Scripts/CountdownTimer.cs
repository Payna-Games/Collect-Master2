using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI timeUpText;
    [SerializeField] private Image timeImage;
    public static int timeDuration;

    private Animator timeImageAnimator;
    [SerializeField] private Animator timeUpAnim;
    //public int countdownDuration = 10; // Başlangıç süresi (saniye)
    private int currentTime;
    private GameManager gameManager;
    public GameData gameData;
    public bool isCountingDown;
    private GameObject joyStick;
    [SerializeField] private PlayerController playerController;
    

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        
        countdownText.text = "00:" + timeDuration.ToString();
        UpdateUI();
        timeImageAnimator = GameObject.Find("TimeImage").GetComponent<Animator>();
        joyStick = GameObject.Find("JoystickCanvas");
        timeUpText.text = "Time Up!";


    }

    public void CountDown()
    {
        countdownText.text = "00:" +timeDuration.ToString();
    }
    public void StartCountdown()
    {
        InvokeRepeating("UpdateCountdown", 1.0f, 1.0f); 
    }

    private void UpdateCountdown()
    {
        
        if (timeDuration > 0)
        {
            timeDuration -= 1; 
            UpdateUI();

            if (timeDuration == 5)
            {
                timeImageAnimator.Play("TimeHurryUp");
                timeImage.color = new Color(1f, 0, 0, 1);
                
            }
            if (timeDuration == 0)
            {
                timeImageAnimator.enabled = false;
                timeUpAnim.Play("TimeUpAnimation");
                joyStick.gameObject.SetActive(false);
                playerController._moveSpeed = 0f;
            }
        }
       
    }

  

    private void UpdateUI()
    {

       
            countdownText.text = "00:" +timeDuration.ToString();
        
        
    }

    private void Update()
    {
       
    }
}
