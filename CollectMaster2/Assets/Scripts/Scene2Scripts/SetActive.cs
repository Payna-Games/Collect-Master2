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
   [SerializeField] private TextMeshProUGUI percent;
   private int objectCount;

  
   private void Start()
   {
      imageRatio = 0;
      objectCount = gameData.collectedObjects.Count;
   }
  

   private string IndexToChange = "null";
   public Transform[] transforms;

   public void RandomGameObject()
   {
      randomIndex = GetUniqueRandomIndex(0, gameData.collectedObjects.Count , usedIndicesGameObject);
      Debug.Log(gameData.collectedObjects.Count);
      string randomObject = gameData.collectedObjects[randomIndex];

      
      randomCubePosition = GetUniqueRandomIndex(0, 87, usedIndicesCube);
      Debug.Log("randomIndex" + randomCubePosition);
         
         
          var gameObject = Instantiate(Resources.Load(randomObject), holeTransform.transform.position, Quaternion.identity);
            gameData.collectedObjects[randomIndex] = IndexToChange;
           //float result = (float)objectCount / 100f;
           // int roundInt = Mathf.RoundToInt(result);
           imageRatio += 0.01f;
            percent.text = (imageRatio*100 ).ToString() + "%";



   }
   //    else if (randomObject == "Cylinder")
   //    {
   //       //kırmızı
   //       randomCubePosition = GetUniqueRandomIndex(9, 18, usedIndicesCylinder);
   //       
   //       
   //       
   //          var gameObject = Instantiate(Resources.Load(randomObject), holeTransform.transform.position, Quaternion.identity);
   //          gameData.collectedObjects[randomIndex] = IndexToChange;
   //       
   //       
   //    }
   //    else if (randomObject == "Capsule")
   //    {
   //       //sarı
   //       randomCubePosition = GetUniqueRandomIndex(18, 27, usedIndicesCapsule);
   //       
   //       
   //          var gameObject = Instantiate(Resources.Load(randomObject), holeTransform.transform.position, Quaternion.identity);
   //          gameData.collectedObjects[randomIndex] = IndexToChange;
   //       
   //       
   //    }
   //    else if (randomObject == "Sphere")
   //    {
   //       //yeşil
   //       randomCubePosition = GetUniqueRandomIndex(27, 36, usedIndicesSphere);
   //       
   //       
   //       
   //          var gameObject = Instantiate(Resources.Load(randomObject), holeTransform.transform.position, Quaternion.identity);
   //          gameData.collectedObjects[randomIndex] = IndexToChange;
   //       
   //       
   //    }
   // }


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



