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
    
    private CountdownTimer countdownTimer;
    public GameData gameData;
    public TextMeshProUGUI coinText;
    
    [SerializeField] private TextMeshProUGUI timeLevelText;
    [SerializeField] private TextMeshProUGUI holeLevelText;
    [SerializeField] private TextMeshProUGUI IncomeLevelText;
    
    
    
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

    }
    public void TimeButton()
    {

        gameData.timeDuration += 5;
        gameData.timeLevel++;
        timeLevelText.text ="Level: " + gameData.timeLevel.ToString();


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
            
            Debug.Log("tıklandı");
        }
    }

    public void Coin()
    {
        coinText.text = gameData.coin.ToString() + destroyTrigger.increaseCoin;
    }
    
    public void Update()
    {
        if (!gameOver)
        {
           
            
           
        }
    }
}
