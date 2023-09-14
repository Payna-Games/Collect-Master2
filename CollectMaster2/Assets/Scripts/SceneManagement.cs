using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private GameManager gameManager;
    public GameData gameData;
    private int currentSceneIndex;
    
    private void Awake()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            gameData.timeDuration = 25;
        }
    }
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //_gameManager.gameOver = false;
    }

    // Update is called once per frame
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
        
    }
}
