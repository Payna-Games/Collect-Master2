using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    
    
    public GameObject[] targetPosition;
    private  Rigidbody rb;
    

   

    public static CollectObject Create( Vector3 position)
    {
        GameObject collectObjectTransform = Instantiate(GameAssets.i.collectedObjPrefabs[0], position, Quaternion.Euler(45, 0, 0));
        CollectObject collectObject = collectObjectTransform.GetComponent<CollectObject>();
        collectObject.rb = collectObjectTransform.GetComponent<Rigidbody>();
        
        
        collectObject.RigdBody(0);
       
        
        return collectObject;
    }

    public void RigdBody(int randomTargetPosition)
    {
       
        
       // Vector3 direction = targetPosition[randomTargetPosition].transform.position -  transform.position;
        //transform.rotation = Quaternion.LookRotation(direction);
        float forceMagnitude = 5f; 
      //  Vector3 forceDirection = direction.normalized; 
        Vector3 force = transform.up* forceMagnitude;
        rb.velocity = force;
    }
   // private static int CreateRandomNumbers(int min, int max)
   // {


      //  int randomNumber = Random
      //  return randomNumber;


  //  }
    
}
    

    
