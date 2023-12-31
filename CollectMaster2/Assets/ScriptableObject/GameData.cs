using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewGameData", menuName = "Custom/GameData")]
public class GameData :  ScriptableObject
{
     public GameData gameData;
     public int timeDuration;
     public int timeSave;
     public float holeSize;
     public int income;
     public int coin;
     public List<string> collectedObjects = new List<string>();
     
     public int holeSizeLevel;
     public int timeLevel;
     public int IncomeLevel;
     public int scene = 0;
     public int holeSizeCoin;
     public int timeCoin;
     public int incomeCoin;
     public int increaseCoin;
     public Vector3 holeScale;
     public int currentSizeIndex;
     
     public List<int> incomePreis;
     public List<int> holePreis;
     public List<int> timePreis;

     public int i;
     public int h;
     public int t;

}
