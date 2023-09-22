using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;
    private int RandomIndex;
    private int i = 0;
    public static GameData gameData;
    [SerializeField] private Transform objTransform;

    [SerializeField]
    private float requiredHoldTime;

    public UnityEvent onLongClick;

    //[SerializeField] private Image fillImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("OnPointerUp");
    }

    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();

                Reset();
            }
            //fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
            while (i<gameData.collectedObjects.Count)
            {
                RandomIndex = Random.Range(0, gameData.collectedObjects.Count);
                gameData.collectedObjects.RemoveAt(RandomIndex);
                i++;
                Debug.Log(RandomIndex);
            }
            
            
            //var randomObject = gameData.collectedObjects[RandomIndex];
            //Instantiate(Resources.Load("Cube"), objTransform.position, Quaternion.identity);
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
       // fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }

}

