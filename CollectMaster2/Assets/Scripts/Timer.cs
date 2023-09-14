using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText;
    public int countdownDuration = 10; // Başlangıç süresi (saniye)
    private int currentTime;

    private void Start()
    {
        currentTime = countdownDuration;
        UpdateUI();
        InvokeRepeating("UpdateCountdown", 1.0f, 1.0f); // Her saniyede bir UpdateCountdown metodunu çağırır
    }

    private void UpdateCountdown()
    {
        if (currentTime > 0)
        {
            currentTime -= 1; // Her saniyede bir azalt
            UpdateUI();
        }
        else
        {
            currentTime = 0; // Sayaç sıfırın altına düşmesini önler
            // Sayaç süresi bittiğinde yapılacak işlemleri burada ekleyebilirsiniz.
        }
    }

    private void UpdateUI()
    {
        // Geri sayım metnini güncelle
        countdownText.text = currentTime.ToString();
    }
}
