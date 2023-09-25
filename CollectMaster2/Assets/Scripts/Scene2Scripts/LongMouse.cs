using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown = false;
    private float pointerDownTimer;
    private bool canCallMethod = true;
    public float callCooldown = 0.2f;

   
    private float requiredHoldTime;

    public UnityEvent onLongClick;

    //[SerializeField private Image fillImage;

    [SerializeField] private SetActive setActiveScript;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        //Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
       // Debug.Log("OnPointerUp");
    }

    private void Update()
    {
        if (pointerDown && canCallMethod)
        {
            // pointerDownTimer += Time.deltaTime;
            // if (pointerDownTimer >= requiredHoldTime)
            // {
            //     if (onLongClick != null)
            //         onLongClick.Invoke();
            //
            //     Reset();
            // }
            // fillImage.fillAmount = pointerDownTimer / requiredHoldTime;


            // pointerDownTimer += Time.deltaTime;

            setActiveScript.RandomGameObject();
            canCallMethod = false;
            StartCoroutine(ResetCallCooldown());


        }

    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        //fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }
    private  IEnumerator ResetCallCooldown()
    {
        yield return new WaitForSeconds(callCooldown);
        
        canCallMethod = true; // Bir sonraki çağrıyı kabul et
    }
}