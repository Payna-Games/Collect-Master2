using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InstantiateObject : MonoBehaviour
{
    private Transform targetPosition;
    private float duration = 2f;
    private AnimationCurve curve;
    private SetActive setActiveScript;

    private void Awake()
    {
        setActiveScript = GameObject.Find("GameManager2").GetComponent<SetActive>();
        targetPosition = setActiveScript.transforms[setActiveScript.randomCubePosition];
    }

    private void Start()
    {
        transform.DOMove( targetPosition.position, duration);
        //transform.DOMove(targetPosition.position, duration);
    }
}
