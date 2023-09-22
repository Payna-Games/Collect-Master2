using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjSpawn : MonoBehaviour
{
    public GameData gameData;
    [SerializeField] private Transform holeTransform;
    private bool onMouseDown = false;
    private int i = 0;

    private void OnMouseDown()
    {
        onMouseDown = true;
    }

    private void OnMouseUp()
    {
        onMouseDown = false;
    }


    private void Update()
    {
        if (onMouseDown)
        {
            string randomObject = gameData.collectedObjects[i];
            GameObject instantiatedObject = Instantiate(Resources.Load(randomObject), holeTransform.position, Quaternion.identity) as GameObject;
        }
    }
}
