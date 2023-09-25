using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFlBoxes : MonoBehaviour
{
   
    
    public void SetActiveField(Vector3 center,float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var hitCollider in hitColliders)
        {
            hitCollider.gameObject.SetActive(true);
            Debug.Log("metot çalışıyor");
            
        }
       
           
    }
}
