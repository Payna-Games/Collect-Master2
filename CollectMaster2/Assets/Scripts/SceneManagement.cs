using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private GameManager gameManagerScript;
    private GameObject gameManagerObject;
    private GameManager2 gameManager2Script;
    private GameObject gameManager2Object;
    
    public GameData gameData;
    private int currentSceneIndex;
    
   

    [SerializeField] private DestroyTrigger destroyTrigger;
    //private CountdownTimer timer;
    
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        
        if (currentSceneIndex == 0 )
        {
            gameData.tryAgain = false;
            //
            // if (!PlayerPrefs.HasKey("TimeDuration"))
            // {
            //     LoadGameData();
            // }
            // else if (PlayerPrefs.HasKey("TimeDuration"))
            // {
            //    GetGameData();
            // }

            if (gameData.scene == 0)
            {
                LoadGameData();
               // gameData.timeDuration = 5;
            }

            CountdownTimer.timeDuration = gameData.timeDuration;
            gameData.collectedObjects.Clear();
            
        }
       
       


    }
    
    void Start()
    {
        gameManagerObject = GameObject.Find("Game Manager");
        gameManager2Object = GameObject.Find("GameManager2");
        if (gameManagerObject != null)
        {
            gameManagerScript = gameManagerObject.GetComponent<GameManager>();
        }
        if (gameManager2Object != null)
        {
            gameManager2Script = gameManager2Object.GetComponent<GameManager2>();
        }
       
        

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
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex-1);
        gameData.tryAgain = true;

    }
    
    void Update()
    {
        if (CountdownTimer.timeDuration == 0 || destroyTrigger.objCount == destroyTrigger.objCountLimit )
        {
            StartCoroutine(WaitForSeconds());
        }
        
    }
    private IEnumerator WaitForSeconds()
    {
        

       
        yield return new WaitForSeconds(2f);
        NextScene();

        
    }
    private void LoadGameData()
    {
        
        
            
            //PlayerPrefs.SetInt("TimeDuration" ,5);
            gameData.coin = PlayerPrefs.GetInt("Coin", 0);
            gameData.holeSizeLevel = PlayerPrefs.GetInt("HoleSizeLevel", 0);
            gameData.timeLevel = PlayerPrefs.GetInt("TimeLevel", 0);
            gameData.IncomeLevel = PlayerPrefs.GetInt("IncomeLevel", 0);
        
    }

    // private void SetGameData()
    // {
    //     PlayerPrefs.SetInt("Coin" ,gameData.coin);
    //     PlayerPrefs.SetInt("HoleSizeLevel" ,gameData.holeSizeLevel);
    //     PlayerPrefs.SetInt("TimeLevel" ,gameData.timeLevel);
    //     PlayerPrefs.SetInt("IncomeLevel" , gameData.IncomeLevel);
    //     
    // }
    //
    // private void OnDisable()
    // {
    //     SetGameData();
    // }
    //
    // private void GetGameData()
    // {
    //     gameData.timeDuration = PlayerPrefs.GetInt("TimeDuration");
    //     gameData.coin = PlayerPrefs.GetInt("Coin");
    //     gameData.holeSizeLevel = PlayerPrefs.GetInt("HoleSizeLevel" );
    //     gameData.timeLevel = PlayerPrefs.GetInt("TimeLevel" );
    //     gameData.IncomeLevel = PlayerPrefs.GetInt("IncomeLevel" );
    // }
}
    
    

