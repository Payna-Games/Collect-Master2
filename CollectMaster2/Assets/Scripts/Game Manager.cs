using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    private GameObject buttons;
    private GameObject hole;
    [SerializeField] private HoleSize holeSize;
    private CountdownTimer countdownTimer;
    public GameData gameData;
    
    
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
        gameOver = false;
        countdownTimer.isCountingDown = true;
        //timer.StartCountdown();
    }
   
    
    void Update()
    {
        if (!gameOver)
        {
            buttons.SetActive(false);
        }
    }
}
