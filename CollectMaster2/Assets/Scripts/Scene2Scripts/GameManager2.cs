using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
   public GameData gameData;
   [SerializeField] private Image fillImage;
   [SerializeField] private int imageFillSpeed;
   private int objCountLimit;
   private SetActive setActive;
   


   private void Start()
   {
      fillImage.fillAmount = 0;
      setActive = GetComponent<SetActive>();
     
   }

   private void Update()
   {
      
         
         fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, setActive.imageRatio , Time.deltaTime * imageFillSpeed);
         Debug.Log("imageRatio" + setActive.imageRatio);
         Debug.Log( " Count "+ gameData.collectedObjects.Count );
         
      
      
   }
}
