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
    
    private CountdownTimer countdownTimer;
    public GameData gameData;
    public TextMeshProUGUI coinText;
    
    
    void Start()
    {
        gameOver = true;
        buttons = GameObject.Find("Buttons");
        hole = GameObject.Find("HoleParent");
        countdownTimer = GetComponent<CountdownTimer>();
    }

    public void HoleSizeButton()
    {
        hole.transform.localScale += holeSize.scaleStep * Vector3.one;

    }
    public void TimeButton()
    {

        gameData.timeDuration += 5;

    }
    public void IncomeButton()
    {
        
        

    }

    public void ScreenButton()
    {
        if (!countdownTimer.isCountingDown)
        {
            gameOver = false;
            countdownTimer.isCountingDown = true;
            countdownTimer.StartCountdown();
            
            Debug.Log("tıklandı");
        }
    }

    public void Coin()
    {
        coinText.text = gameData.coin.ToString();
    }
    
    public void Update()
    {
        if (!gameOver)
        {
           
            
           
        }
    }
}
