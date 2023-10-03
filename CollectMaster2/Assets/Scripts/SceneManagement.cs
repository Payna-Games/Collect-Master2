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
    
    
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        
        
        
        if (currentSceneIndex == 1 )
        {
            
         
            if (gameData.scene == 0)
            {
                LoadGameData();
               CountdownTimer.time = 15;
               gameData.timeDuration = 15;
               gameData.cameraIndex = 0;
               gameData.i = 0;
               gameData.h = 0;
               gameData.t = 0;

            }
            
            
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
        if ( gameData.timeDuration == 0 || destroyTrigger.objCount == destroyTrigger.objCountLimit )
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
        
        
            
            
            gameData.coin = PlayerPrefs.GetInt("Coin", 0);
            gameData.holeSizeLevel = PlayerPrefs.GetInt("HoleSizeLevel", 0);
            gameData.timeLevel = PlayerPrefs.GetInt("TimeLevel", 0);
            gameData.IncomeLevel = PlayerPrefs.GetInt("IncomeLevel", 0);
            gameData.increaseCoin = PlayerPrefs.GetInt("IncreaseCoin", 0);
            gameData.timeDuration = PlayerPrefs.GetInt("timeDuration", 5);
            gameData.h=PlayerPrefs.GetInt("h", 0);
            gameData.t=PlayerPrefs.GetInt("t", 0);
            gameData.i=PlayerPrefs.GetInt("i", 0);
            
    }

  
}
    
    

