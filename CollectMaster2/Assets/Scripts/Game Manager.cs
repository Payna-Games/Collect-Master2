using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameOver;
    private GameObject buttons;
    private GameObject hole;
    [SerializeField] private HoleSize holeSize;
    void Start()
    {
        gameOver = true;
        buttons = GameObject.Find("Buttons");
        hole = GameObject.Find("HoleParent");

    }

    public void HoleSizeButton()
    {
        hole.transform.localScale += holeSize.scaleStep * Vector3.one;

    }
    public void TimeButton()
    {
        
        

    }
    public void IncomeButton()
    {
        
        

    }

    public void ScreenButton()
    {
        gameOver = false;
    }
   
    
    void Update()
    {
        if (!gameOver)
        {
            buttons.SetActive(false);
        }
    }
}
