using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
   public GameData gameData;
   [SerializeField] private Image fillImage;
   [SerializeField] private int imageFillSpeed;
   [SerializeField] private TextMeshProUGUI percent;
   private int objCountLimit;
   private SetActive setActive;
   public float fillAmount;
  
   
   
   


   private void Start()
   {
      fillImage.fillAmount = 0;
      setActive = GetComponent<SetActive>();
      
      

   }

   
   void UpdateFillAmount()
   {
       fillAmount = Mathf.Lerp(fillImage.fillAmount, (float)setActive.collectedObjectCount /136f, Time.deltaTime * imageFillSpeed);
       fillImage.fillAmount = fillAmount;
       percent.text = (fillAmount*100).ToString("F0") + "%";
   }

   private void Update()
   {
      
         
       UpdateFillAmount();
       
         
         
      
      
   }
}
