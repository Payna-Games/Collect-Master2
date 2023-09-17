using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
   [SerializeField] private Transform collectedCoin;

   private void Start()
   {
      Instantiate(collectedCoin, Vector3.zero, Quaternion.identity);
   }
}
