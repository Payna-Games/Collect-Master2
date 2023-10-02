using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Slider Loadingslider; 
    void Start()
    {
        StartCoroutine(LoadAsycn());
    }

    IEnumerator LoadAsycn()
    {
        AsyncOperation Op = SceneManager.LoadSceneAsync(1);
        while (!Op.isDone)
        {
            float progress = Mathf.Clamp01(Op.progress / .9f);
            Loadingslider.value = progress;
            yield return null;
        }
    }
}
