using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAnimation : MonoBehaviour
{
    private bool tutorial2;
   public Animator holdtofillanim;
   [SerializeField] private GameObject holdtoFill;

   

   void Start()
    {
        if (PlayerPrefs.GetInt("tutorial2", 1) == 1)
        {
            
            tutorial2 = true;

            PlayerPrefs.SetInt("tutorial", 0);
        }
        else
        {
            tutorial2 = false;
          //  holdtofillanim.Stop("HoldToFill");
            holdtoFill.gameObject.SetActive(false);
        }
    }

    private void StartAnim()
    {
        holdtoFill.gameObject.SetActive(true);
        holdtofillanim.Play("HoldtoFill");
    }
}
