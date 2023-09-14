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
    public Animator animator;
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
            //timer.StartCountdown();
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
            animator.SetBool("Down",true);
            //animator.gameObject.SetActive(true);
            buttons.SetActive(false);
        }
    }
}
