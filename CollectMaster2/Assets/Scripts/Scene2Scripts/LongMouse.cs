using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown = false;
    private bool canCallMethod = true;
    public float callCooldown = 0.2f;
    private float requiredHoldTime;
    
    public UnityEvent onLongClick;
    [SerializeField] private SetActive setActiveScript;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
      
    }

    private void Update()
    {
        if (pointerDown && canCallMethod)
        {
            setActiveScript.RandomGameObject();
            canCallMethod = false;
            StartCoroutine(ResetCallCooldown());
        }

    }

   
    private  IEnumerator ResetCallCooldown()
    {
        yield return new WaitForSeconds(callCooldown);
        
        canCallMethod = true; 
    }
}