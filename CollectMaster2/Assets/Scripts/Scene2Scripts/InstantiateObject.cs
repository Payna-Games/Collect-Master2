using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InstantiateObject : MonoBehaviour
{
    private Transform targetPosition;
    private float duration = 0.75f;
    public AnimationCurve[] curve;

    private SetActive setActiveScript;
    

    private void Awake()
    {
        setActiveScript = GameObject.Find("GameManager2").GetComponent<SetActive>();
        targetPosition = setActiveScript.transforms[setActiveScript.randomCubePosition];
    }

    private void Start()
    {
        transform.DOLocalMoveY(targetPosition.localPosition.y + 0.4f, duration / 2f).SetEase(curve[0]).OnComplete(() =>
        {
            transform.DOMove(targetPosition.position, duration).SetEase(curve[1]).OnComplete(() =>
            {

                
                
                SetActiveField(targetPosition.position, 0.2f);
                Destroy(gameObject);
            });
        });


    }

    private void SetActiveField(Vector3 center,float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var hitCollider in hitColliders)
        {
            hitCollider.gameObject.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("metot çalışıyor");
            
        }
       
           
    }
}
