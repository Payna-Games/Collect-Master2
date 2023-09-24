using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;




public class SetActive : MonoBehaviour
{
   public GameData gameData;
   [SerializeField] private Transform holeTransform;
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
      randomIndex = GetUniqueRandomIndex(0, gameData.collectedObjects.Count , usedIndicesGameObject);
      string randomObject = gameData.collectedObjects[randomIndex];
      var gameObject =Instantiate(Resources.Load(randomObject), holeTransform.transform.position,Quaternion.identity);


      Debug.Log("randomIndex" + randomIndex);

      if (randomObject == "Cube")
      {
         //mavi
         randomCubePosition = GetUniqueRandomIndex(0, 9, usedIndicesCube);
         transforms[randomCubePosition].gameObject.SetActive(true);
         Debug.Log( randomCubePosition);
        
      }
      else if (randomObject == "Cylinder")
      {
         //kırmızı
         randomCubePosition = GetUniqueRandomIndex(9, 18, usedIndicesCylinder);
         transforms[randomCubePosition].gameObject.SetActive(true);
         Debug.Log( randomCubePosition);
         
      }
      else if (randomObject == "Capsule")
      {
         //sarı
         randomCubePosition = GetUniqueRandomIndex(18, 27, usedIndicesCapsule);
         transforms[randomCubePosition].gameObject.SetActive(true);
         Debug.Log( randomCubePosition);
        
      }
      else if (randomObject == "Sphere")
      {
         //yeşil
         randomCubePosition = GetUniqueRandomIndex(27, 36, usedIndicesSphere);
         transforms[randomCubePosition].gameObject.SetActive(true);
         Debug.Log( randomCubePosition);
       
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



