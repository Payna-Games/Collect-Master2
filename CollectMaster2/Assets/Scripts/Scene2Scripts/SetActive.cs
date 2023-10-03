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
      randomCubePosition = GetUniqueRandomIndex(0, 87, usedIndicesCube);




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
        
         if (gameManager2.fillAmount < 1)
         {
            
            StartCoroutine(NextSceneTimer());
         }
        
         if (gameManager2.fillAmount == 1) 
         {
            tryAgainText.text = "Well Done";
            anim.Play("TimeUpAnimation");
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

   private IEnumerator NextSceneTimer()
   {
      yield return new WaitForSeconds(3); // İlk bekleme süresi
      tryAgainText.text = "Try Again!";
      anim.Play("TimeUpAnimation");
     
      otherScene = true;

      yield return new WaitForSeconds(2); // İkinci bekleme süresi

      if (otherScene)
      {
         sceneManagement.TryAgainScene();
         gameData.scene++;
         holeToFill.SetActive((false));
      }

      
   }
}



