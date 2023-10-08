using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SmoothFall : MonoBehaviour
{
public float jumpHeight = 0.1f;
public float jumpDuration = 0.1f;

private bool jumpNumber;

private Vector3 initialPosition;

private void Start()
{
    DOTween.SetTweensCapacity(1000, 500);
    initialPosition = transform.localPosition;

    
    
    jumpNumber = true;
}

private void JumpAndReturnAnimation()
{
    
    transform.DOLocalJump(initialPosition + Vector3.up * jumpHeight, 0.01f, 1, jumpDuration);
    
}



private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Hole") && jumpNumber)
    {
        JumpAndReturnAnimation();
        jumpNumber = false;

    }
}
}
