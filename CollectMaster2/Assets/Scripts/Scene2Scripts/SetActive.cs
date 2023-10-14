using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class SetActive : MonoBehaviour
{


   public GameData gameData;
   [SerializeField] private Transform holeTransform;
   private int randomIndex;
   public int randomCubePosition;
   List<int> usedIndicesGameObject = new List<int>();
   List<int> usedIndicesCube = new List<int>();
   public int objectCount;
   bool allObjectsAreDeleted = true;
   private string IndexToChange = "deleted";
   public Transform[] transforms;
   
   
   [SerializeField] private TextMeshProUGUI tryAgainText;
   [SerializeField] private Animator anim;
   [SerializeField] private GameObject holeToFill;
   private GameManager2 gameManager2;
   public int collectedObjectCount;
   
    private SceneManagement sceneManagement;
    private bool otherScene;


   private void Start()
   {
      
      objectCount = gameData.collectedObjects.Count;
      sceneManagement = GetComponent<SceneManagement>();
      gameManager2 = GetComponent<GameManager2>();
      collectedObjectCount = 0;
   }



   public void RandomGameObject()
   {
      randomIndex = GetUniqueRandomIndex(0, gameData.collectedObjects.Count, usedIndicesGameObject);
      string randomObject = gameData.collectedObjects[randomIndex];
      randomCubePosition = GetUniqueRandomIndex(0, 121, usedIndicesCube);




      foreach (string obj in gameData.collectedObjects)
      {
         if (obj != "deleted")
         {
            allObjectsAreDeleted = false;
            break;
         }

      }

      if (!allObjectsAreDeleted)
      {
         
         var gameObject = Instantiate(Resources.Load(randomObject), holeTransform.transform.position, Quaternion.identity);
         gameData.collectedObjects[randomIndex] = IndexToChange;
         collectedObjectCount++;
         objectCount--;
         
         
        
         allObjectsAreDeleted = true;
      }

      if (objectCount ==0)
      {
         otherScene = false;
         
          if (0 <= gameManager2.fillAmount && gameManager2.fillAmount < 0.3f)
         {
            
            StartCoroutine(NextSceneTimer("Try Again"));
         }
        
         else if (gameManager2.fillAmount >=0.99f) 
         {
          
            StartCoroutine(NextSceneTimer("Well Donee!! "));
         }
         else if (0.5f <= gameManager2.fillAmount && gameManager2.fillAmount < 0.8f)
         {
            
            StartCoroutine(NextSceneTimer("Greatt!!"));
         }
         else if (0.3f <= gameManager2.fillAmount && gameManager2.fillAmount < 0.5f)
         {
           
            StartCoroutine(NextSceneTimer("Not Bad"));
         }
          else if (0.8f <= gameManager2.fillAmount && gameManager2.fillAmount < 0.99f)
          {
             StartCoroutine(NextSceneTimer("So Close!!"));
          }

          if (gameData.collectedObjects.Count == 0)
          {
             StartCoroutine(NextSceneTimer("Try Again"));
          }
      }

      
     


      int GetUniqueRandomIndex(int min, int max, List<int> usedList)
      {
         int newIndex;

         while (true)
         {
            newIndex = Random.Range(min, max);

            if (!usedList.Contains(newIndex))
            {
               usedList.Add(newIndex);
               break;
            }

            if (usedList.Count == (max - min))
            {
               newIndex = Random.Range(min, max);
               break;
            }
         }

         return newIndex;
      }
   }

   private IEnumerator NextSceneTimer(string text)
   {
      yield return new WaitForSeconds(3); // İlk bekleme süresi
      tryAgainText.text = text;
      anim.Play("TimeUpAnimation");
     
      otherScene = true;

      yield return new WaitForSeconds(2); // İkinci bekleme süresi

      if (otherScene)
      {
         sceneManagement.TryAgainScene();
         gameData.scene++;
         sceneManagement.SaveData();
         holeToFill.SetActive((false));
      }

      
   }
}



