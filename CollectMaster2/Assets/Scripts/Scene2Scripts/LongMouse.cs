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
    [SerializeField] private Transform objTransform;
    public Transform[] targetPosition; // Hedef pozisyon
    public float moveSpeed = 5f;
    private int randomTargetPositions;

    private GameObject instantiatedObject;

    

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
        Reset();
        Debug.Log("OnPointerUp");
    }

    private bool spawningObject = false;

    private void Update()
    {
        if (pointerDown)
        {
            
            
            
                
            SpawnRandomObject();
            
                   
            
            Vector3 direction = targetPosition[1].position - instantiatedObject.transform.position;
        instantiatedObject.transform.rotation = Quaternion.LookRotation(direction);

        
        Rigidbody rb = instantiatedObject.GetComponent<Rigidbody>();
        float forceMagnitude = 1f; 
        Vector3 forceDirection = direction.normalized; 
        Vector3 force = forceDirection * forceMagnitude;

        rb.AddForce(force, ForceMode.Impulse);
    
        }
    }

    private void SpawnRandomObject()
    {
        RandomIndex = Random.Range(0, gameData.collectedObjects.Count);
        string randomObject = gameData.collectedObjects[RandomIndex];
         instantiatedObject = Instantiate(Resources.Load(randomObject), objTransform.position, Quaternion.identity) as GameObject;

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

    private int TargetObject()
    {
        
    }
    

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
       // fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }

    private int CreateRandomNumbers(int min, int max)
    {
        
        int randomNumber;
        do
        {
            randomNumber = Random.Range(min,max+1);
        } while (usedRandomNumbers.Contains(randomNumber));

        usedRandomNumbers.Add(randomNumber);

        
        if (usedRandomNumbers.Count >= max- min + 1)
        {
            usedRandomNumbers.Clear();
        }

        return randomNumber; 
    }

}

