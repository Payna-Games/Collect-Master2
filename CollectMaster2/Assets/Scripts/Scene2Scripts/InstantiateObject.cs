using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InstantiateObject : MonoBehaviour
{
    private Transform targetPosition;
    private float duration = 1f;
    public AnimationCurve[] curve;

    private SetActive setActiveScript;

    private void Awake()
    {
        setActiveScript = GameObject.Find("GameManager2").GetComponent<SetActive>();
        targetPosition = setActiveScript.transforms[setActiveScript.randomCubePosition];
    }

    private void Start()
    {
        transform.DOLocalMoveY(targetPosition.localPosition.y + 1f, duration / 2f).SetEase(curve[0]).OnComplete(() =>
        {
            transform.DOMove(targetPosition.position, duration).SetEase(curve[1]).OnComplete(() =>
            {

                Destroy(gameObject);
                targetPosition.gameObject.SetActive(true);
            });
        });


    }
}
