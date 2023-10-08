using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SmoothFall : MonoBehaviour
{
public float jumpHeight = 0.1f;
public float jumpDuration = 0.1f;
//public float returnDuration = 0.1f;
private bool jumpNumber;

private Vector3 initialPosition;

private void Start()
{
    DOTween.SetTweensCapacity(1000, 500);
    initialPosition = transform.localPosition;

    // Zıplama ve geri dönme animasyonunu başlatın
    
    jumpNumber = true;
}

private void JumpAndReturnAnimation()
{
    // Nesneyi yukarı zıplatın
    transform.DOLocalJump(initialPosition + Vector3.up * jumpHeight, 0, 1, jumpDuration);
    //.OnComplete(ReturnToInitialPosition); // Zıplama tamamlandığında geri dönme işlemini başlatın
}

// private void ReturnToInitialPosition()
// {
//     // Başlangıç pozisyonuna geri dönme animasyonunu başlatın
//     transform.DOLocalMove(initialPosition, returnDuration);
//     
// }

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Hole") && jumpNumber)
    {
        JumpAndReturnAnimation();
        jumpNumber = false;

    }
}
}
