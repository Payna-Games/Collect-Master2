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
   public float imageRatio;
   private int objectCount;
   bool allObjectsAreDeleted = true;
   private string IndexToChange = "deleted";
   public Transform[] transforms;
   
   [SerializeField] private TextMeshProUGUI percent;
   [SerializeField] private TextMeshProUGUI tryAgainText;
   [SerializeField] private Animator anim;
    private SceneManagement sceneManagement;
    private bool otherScene;


   private void Start()
   {
      imageRatio = 0;
      objectCount = gameData.collectedObjects.Count;
      sceneManagement = GetComponent<SceneManagement>();
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
         objectCount--;
         imageRatio += 0.01f;
         percent.text = (imageRatio*100).ToString("F0") + "%";
         allObjectsAreDeleted = true;
      }

      if (objectCount ==0)
      {
         otherScene = false;
         StartCoroutine(NextSceneTimer(4));
         if (imageRatio < 1)
         {
            otherScene = true;
            tryAgainText.text = "Try Again!";
            anim.Play("TimeUpAnimation");
            StartCoroutine(NextSceneTimer(2));
         }
        
         if (imageRatio == 1) 
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

   private IEnumerator NextSceneTimer(int time)
   {
      yield return new WaitForSeconds(time);

      if (otherScene)
      {
         sceneManagement.TryAgainScene();
      }

      
   }
}



