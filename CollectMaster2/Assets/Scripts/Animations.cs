using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Animations : MonoBehaviour
{
    public Animator animator;
    public Animator coinCollectAnimator;
    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        if (!gameManager.gameOver)
        {
            animator.SetBool("Down",true);
        }
    }
}
