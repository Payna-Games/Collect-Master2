using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
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
    public  GameData gameData;
    public Transform objTransform;
     
    public float moveSpeed = 5f;
    private int randomTargetPositions;

    private GameObject instantiatedObject;
    private string randomObject;

    

    private List<int> usedRandomNumbers;
    

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
       
        Debug.Log("OnPointerUp");
        pointerDown = false;
    }

    private bool spawningObject = false;

    private void Update()
    {
        if (pointerDown)
        {




           // CollectObject.Create(objTransform.position);
            
            

        }

    }



 //  else if (randomObject == "Cylinder")
      //  {
      //      StartCoroutine(MoveObjectToTarget(instantiatedObject));
       // }
      //  else if (randomObject == "Capsule")
       // {
      //      StartCoroutine(MoveObjectToTarget(instantiatedObject));
      //  }
       // else if (randomObject == "Sphere")
      //  {
            
      //  }StartCoroutine(MoveObjectToTarget(instantiatedObject));
    }

    // private int CreateRandomNumbers(int min, int max)
    // {
    //
    //
    //    int randomNumber = Random.Range(min, max);
    //    return randomNumber;
    //
    //
    // }



//     
//     int randomNumber;
//     do
//     {
//         randomNumber = Random.Range(min,max+1);
//     } while (usedRandomNumbers.Contains(randomNumber));
//
//     usedRandomNumbers.Add(randomNumber);
//
//     
//     if (usedRandomNumbers.Count >= max- min + 1)
//     {
//         usedRandomNumbers.Clear();
//     }
//
//     return randomNumber; 