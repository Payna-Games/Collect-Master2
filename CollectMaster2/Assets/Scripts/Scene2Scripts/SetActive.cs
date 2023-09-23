using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetActive : MonoBehaviour
{
   public GameData gameData;
   private int randomIndex;
   private int randomCubePosition;
   List<int> usedIndicesGameObject = new List<int>();
   List<int> usedIndicesCube = new List<int>();
   List<int> usedIndicesCylinder = new List<int>();
   List<int> usedIndicesCapsule = new List<int>();
   List<int> usedIndicesSphere = new List<int>();

   [SerializeField] private Transform[] transforms;

   public void RandomGameObject()
   {
      randomIndex = GetUniqueRandomIndex(0, gameData.collectedObjects.Count - 1, usedIndicesGameObject);
      string randomObject = gameData.collectedObjects[randomIndex];


      Debug.Log("randomIndex" + randomIndex);

      if (randomObject == "Cube")
      {
         //mavi
         randomCubePosition = GetUniqueRandomIndex(0, 8, usedIndicesCube);
         transforms[randomCubePosition].gameObject.SetActive(true);
        
      }
      else if (randomObject == "Cylinder")
      {
         //kırmızı
         randomCubePosition = GetUniqueRandomIndex(8, 18, usedIndicesCylinder);
         transforms[randomCubePosition].gameObject.SetActive(true);
         
      }
      else if (randomObject == "Capsule")
      {
         randomCubePosition = GetUniqueRandomIndex(18, 27, usedIndicesCapsule);
         transforms[randomCubePosition].gameObject.SetActive(true);
        
      }
      else if (randomObject == "Sphere")
      {
         randomCubePosition = GetUniqueRandomIndex(27, 36, usedIndicesSphere);
         transforms[randomCubePosition].gameObject.SetActive(true);
       
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



