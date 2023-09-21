using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private GameManager gameManager;
    public GameData gameData;
    private int currentSceneIndex;
    //private CountdownTimer timer;
    
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //timer = GetComponent<CountdownTimer>();

        if (currentSceneIndex == 0)
        {
            gameData.timeDuration = 25;
            gameData.coin = 0;
            gameData.holeSizeLevel = 0;
            gameData.timeLevel = 0;
            gameData.IncomeLevel = 0;
            gameData.collectedObjects.Clear();
        }
    }
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //_gameManager.gameOver = false;
    }

    
    public void NextScene()
    {

        int nextSceneIndex = currentSceneIndex + 1; 

        
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);

        }
    }

    public void TryAgainScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
    }
    
    void Update()
    {
        if (gameData.timeDuration == -2)
        {
            NextScene();
        }
    }
}
