using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnLongPress : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    [Tooltip("Basılı tutma süresi (saniye cinsinden)")]
    public float longPressDuration = 1.0f;

    [Tooltip("Long press gerçekleştiğinde tetiklenecek UnityEvent")]
    public UnityEvent onLongPress;

    private bool isPressed = false;
    private float pressTime = 0.0f;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        pressTime = Time.time;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    private void Update()
    {
        if (isPressed && Time.time - pressTime >= longPressDuration)
        {
            // Belirtilen süre boyunca basılı tutuldu, olayı tetikle
            onLongPress.Invoke();
            isPressed = false; // Tek seferlik tetikleme için basılı tutma işlemini durdurun
        }
    }
}


