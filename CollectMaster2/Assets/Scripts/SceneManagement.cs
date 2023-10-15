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
    public GameObject buttons;


    public GameData gameData;
    private int currentSceneIndex;
    private bool firstTimeStart;
    private string saveKey = "gameData";
    
    public int holeSizeStopSave;
    public  bool holeSizeStop = false;
    
    


    [SerializeField] private DestroyTrigger destroyTrigger;


    private void Awake()
    {
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        holeSizeStop = false;
        holeSizeStopSave = 0;
        HoleStopSave();


        if ( UnityEngine.PlayerPrefs.GetInt("firstTimeStart", 1) == 1)
         {
             firstTimeStart = true;
                       
            UnityEngine.PlayerPrefs.SetInt("firstTimeStart", 0);             
                          
         }
        else
         {
             firstTimeStart = false;
             
        
         }
           if (firstTimeStart)
           {
               LoadGameData();
                
                gameData.i = 0;
                gameData.h = 0;
                gameData.t = 0;
                gameData.timeSave = 15;
                gameData.timeDuration = 15;
               // SaveData();
                
           }

           if (!firstTimeStart)
           {
               Debug.Log("kaydetmesi lazım");
               gameData.coin = UnityEngine.PlayerPrefs.GetInt(saveKey+"coin", gameData.coin);
               gameData.increaseCoin= UnityEngine.PlayerPrefs.GetInt(saveKey+"increaseCoin", gameData.increaseCoin);
        
               gameData.h=UnityEngine.PlayerPrefs.GetInt(saveKey+"h", gameData.h);
               gameData.i = UnityEngine.PlayerPrefs.GetInt(saveKey+"i", gameData.i);
               gameData.t =UnityEngine.PlayerPrefs.GetInt(saveKey+"t", gameData.t);
               //income
               gameData.income = UnityEngine.PlayerPrefs.GetInt(saveKey+"income", gameData.income);
               gameData.incomeCoin = UnityEngine.PlayerPrefs.GetInt(saveKey+"incomeCoin", gameData.incomeCoin);
        
               gameData.IncomeLevel =UnityEngine.PlayerPrefs.GetInt(saveKey+"IncomeLevel", gameData.IncomeLevel);
               //time
               gameData.timeCoin =UnityEngine.PlayerPrefs.GetInt(saveKey+"timeCoin", gameData.timeCoin);
        
               gameData.timeLevel =UnityEngine.PlayerPrefs.GetInt(saveKey+"timeLevel", gameData.timeLevel);
               //gameData.timeDuration =UnityEngine.PlayerPrefs.GetInt(saveKey, gameData.timeDuration);
               gameData.timeDuration =UnityEngine.PlayerPrefs.GetInt(saveKey+"timeSave", gameData.timeSave);
               //hole
        
               gameData.holeSizeCoin =  UnityEngine.PlayerPrefs.GetInt(saveKey+"holeSizeCoin", gameData.holeSizeCoin);
               gameData.holeSizeLevel =  UnityEngine.PlayerPrefs.GetInt(saveKey+"holeSizeLevel", gameData.holeSizeLevel);
               gameData.holeScale.x =  UnityEngine.PlayerPrefs.GetFloat(saveKey+"holeScale.x", gameData.holeScale.x);
               gameData.holeScale.y =  UnityEngine.PlayerPrefs.GetFloat(saveKey+"holeScale.y", gameData.holeScale.y);
               gameData.holeScale.z =  UnityEngine.PlayerPrefs.GetFloat(saveKey+"holeScale.z", gameData.holeScale.z);
        
               gameData.currentSizeIndex= UnityEngine.PlayerPrefs.GetInt(saveKey+"currentSizeIndex", gameData.currentSizeIndex);
               gameData.scene = UnityEngine.PlayerPrefs.GetInt(saveKey+"scene", gameData.scene);
           }

        GameObject saveTransformHole = GameObject.Find("GAMEPLAY/HoleParent");
        if (gameData.scene > 0)
        {
            buttons.gameObject.SetActive(true);
        }

        if (currentSceneIndex == 1)
        {
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
            SaveData();
            SceneManager.LoadScene(nextSceneIndex);
            

        }
        
    }

    public void TryAgainScene()
    {
        SaveData();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex - 1);
        
        
        

    }

    void Update()
    {
        if (gameData.timeDuration == 0 || gameData.collectedObjects.Count == destroyTrigger.objCountLimit)
        {
            StartCoroutine(WaitForSeconds());
            SaveData();
        }

    }

    private IEnumerator WaitForSeconds()
    {



        yield return new WaitForSeconds(2f);
        NextScene();


    }

    private void LoadGameData()
    {
    
    
    
    
        gameData.coin =  UnityEngine.PlayerPrefs.GetInt("Coin", 0);
        gameData.holeSizeLevel =  UnityEngine.PlayerPrefs.GetInt("HoleSizeLevel", 0);
        gameData.timeLevel =  UnityEngine.PlayerPrefs.GetInt("TimeLevel", 0);
        gameData.IncomeLevel =  UnityEngine.PlayerPrefs.GetInt("IncomeLevel", 0);
        gameData.increaseCoin =  UnityEngine.PlayerPrefs.GetInt("IncreaseCoin", 0);
      
        gameData.h =  UnityEngine.PlayerPrefs.GetInt("h", 0);
        gameData.t =  UnityEngine.PlayerPrefs.GetInt("t", 0);
        gameData.t =  UnityEngine.PlayerPrefs.GetInt("i", 0);
    }
     public void SaveData()
    {
        
        UnityEngine.PlayerPrefs.SetInt(saveKey+"coin", gameData.coin);
        UnityEngine.PlayerPrefs.SetInt(saveKey+"increaseCoin", gameData.increaseCoin);
        
        UnityEngine.PlayerPrefs.SetInt(saveKey+"h", gameData.h);
        UnityEngine.PlayerPrefs.SetInt(saveKey+"i", gameData.i);
        UnityEngine.PlayerPrefs.SetInt(saveKey+"t", gameData.t);
        //income
        UnityEngine.PlayerPrefs.SetInt(saveKey+"income", gameData.income);
        UnityEngine.PlayerPrefs.SetInt(saveKey+"incomeCoin", gameData.incomeCoin);
        
        UnityEngine.PlayerPrefs.SetInt(saveKey+"IncomeLevel", gameData.IncomeLevel);
        //time
        UnityEngine.PlayerPrefs.SetInt(saveKey+"timeCoin", gameData.timeCoin);
        
        UnityEngine.PlayerPrefs.SetInt(saveKey+"timeLevel", gameData.timeLevel);
        //UnityEngine.PlayerPrefs.SetInt(saveKey, gameData.timeDuration);
       UnityEngine.PlayerPrefs.SetInt(saveKey+"timeSave", gameData.timeSave);
        //hole
        
        UnityEngine.PlayerPrefs.SetInt(saveKey+"holeSizeCoin", gameData.holeSizeCoin);
        UnityEngine.PlayerPrefs.SetInt(saveKey+"holeSizeLevel", gameData.holeSizeLevel);
        UnityEngine.PlayerPrefs.SetFloat(saveKey+"holeScale.x", gameData.holeScale.x);
        UnityEngine.PlayerPrefs.SetFloat(saveKey+"holeScale.y", gameData.holeScale.y);
        UnityEngine.PlayerPrefs.SetFloat(saveKey+"holeScale.z", gameData.holeScale.z);
        
        UnityEngine.PlayerPrefs.SetInt(saveKey+"currentSizeIndex", gameData.currentSizeIndex);
        UnityEngine.PlayerPrefs.SetInt(saveKey+"scene", gameData.scene);
        
        
        //UnityEngine.PlayerPrefs.SetInt(saveKey, gameData.collectedObjects);
        
        
        
        
    }

     public void HoleStopSave()
     {
         UnityEngine.PlayerPrefs.SetInt(saveKey+"holeSizeStop",holeSizeStopSave);
     }

    
}