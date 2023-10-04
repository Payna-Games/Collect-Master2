using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;

public class InstantiateObject : MonoBehaviour
{
    private Transform targetPosition;
    private float duration = 0.75f;
    public AnimationCurve[] curve;

    private SetActive setActiveScript;
    [SerializeField] private ParticleSystem particleEffect;
    

    private void Awake()
    {
        setActiveScript = GameObject.Find("GameManager2").GetComponent<SetActive>();
        targetPosition = setActiveScript.transforms[setActiveScript.randomCubePosition];
    }

    private void Start()
    {
        transform.DOLocalMoveY(targetPosition.localPosition.y + 0.05f, duration / 4f).SetEase(curve[0]).OnComplete(() =>
        {
            transform.DOMove(targetPosition.position, duration/2f).SetEase(curve[1]).OnComplete(() =>
            {

                
                
                SetActiveField(targetPosition.position, 0.2f);
                Destroy(gameObject);
                
                if (setActiveScript.randomCubePosition <= 30)
                {
                    Instantiate(GameAssets.i.effects[2], transform.position, quaternion.identity);
                    particleEffect.Play();
                }
                else if (31 <= setActiveScript.randomCubePosition && setActiveScript.randomCubePosition <= 63)
                {
                    Instantiate(GameAssets.i.effects[0], transform.position, quaternion.identity);
                    particleEffect.Play();
                }
                else if(64 <= setActiveScript.randomCubePosition && setActiveScript.randomCubePosition <= 86)
                {
                    Instantiate(GameAssets.i.effects[1], transform.position, quaternion.identity);
                    particleEffect.Play();
                }
                
            });
        });


    }

    private void SetActiveField(Vector3 center,float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var hitCollider in hitColliders)
        {
            hitCollider.gameObject.GetComponent<MeshRenderer>().enabled = true;
          
        }
       
           
    }
}
