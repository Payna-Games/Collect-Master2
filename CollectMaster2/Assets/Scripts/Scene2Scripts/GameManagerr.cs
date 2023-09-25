using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
   public GameData gameData;
   [SerializeField] private Image fillImage;
   [SerializeField] private float imageFillSpeed;
   [SerializeField] private int objCountLimit;

   private void Update()
   {
      float imageRatio = gameData.collectedObjects.Count / objCountLimit;
      fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, imageRatio , Time.deltaTime * imageFillSpeed);
   }
}
