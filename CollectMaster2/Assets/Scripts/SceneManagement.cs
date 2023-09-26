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
        
    }
    
    void Update()
    {
        if (gameData.timeDuration == 0 || destroyTrigger.objCount == destroyTrigger.objCountLimit )
        {
            StartCoroutine(WaitForSeconds());
        }
        
    }
    private IEnumerator WaitForSeconds()
    {
        

       
        yield return new WaitForSeconds(2f);
        NextScene();

        
    }
}
    
    

