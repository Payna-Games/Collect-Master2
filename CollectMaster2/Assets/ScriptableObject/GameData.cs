using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewGameData", menuName = "Custom/GameData")]
public class GameData :  ScriptableObject
{
     public GameData gameData;
     public int timeDuration;
     public float holeSize;
     public int income;
     public int coin;
     public List<string> collectedObjects = new List<string>();
     public int holeSizeLevel;
     public int timeLevel;
     public int IncomeLevel;
     
}
