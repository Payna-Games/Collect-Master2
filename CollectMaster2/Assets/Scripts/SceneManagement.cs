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

    


    [SerializeField] private DestroyTrigger destroyTrigger;


    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;




        //if (currentSceneIndex == 1)
        //{


           // if (gameData.scene == 0)
           // {
                LoadGameData();
                CountdownTimer.time = 60;
                gameData.timeDuration = 60;
                gameData.i = 0;
                gameData.h = 0;
                gameData.t = 0;

           // }

            if (gameData.scene > 0)
            {
                buttons.gameObject.SetActive(true);
            }

            gameData.collectedObjects.Clear();

       // }

        GameObject saveTransformHole = GameObject.Find("GAMEPLAY/HoleParent");
       

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
        SceneManager.LoadScene(currentSceneIndex - 1);
        
        

    }

    void Update()
    {
        if (gameData.timeDuration == 0 || destroyTrigger.objCount == destroyTrigger.objCountLimit)
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




        gameData.coin = PlayerPrefs.GetInt("Coin", 50000);
        gameData.holeSizeLevel = PlayerPrefs.GetInt("HoleSizeLevel", 0);
        gameData.timeLevel = PlayerPrefs.GetInt("TimeLevel", 0);
        gameData.IncomeLevel = PlayerPrefs.GetInt("IncomeLevel", 0);
        gameData.increaseCoin = PlayerPrefs.GetInt("IncreaseCoin", 0);
        gameData.timeDuration = PlayerPrefs.GetInt("timeDuration", 500);
        gameData.h = PlayerPrefs.GetInt("h", 0);
        gameData.t = PlayerPrefs.GetInt("t", 0);
        gameData.t = PlayerPrefs.GetInt("i", 0);
    }
}