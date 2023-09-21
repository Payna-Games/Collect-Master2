using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    private int RandomIndex;
    [SerializeField] private int RandomGameDataObj;
    public static GameData gameData;
    [SerializeField] private Transform objTransform;


   

    public void CreateObj()
    {
        var randomObject = gameData.collectedObjects[RandomGameDataObj];
        Instantiate(Resources.Load(randomObject), objTransform.position, Quaternion.identity);
    
        
    } }
    

    
