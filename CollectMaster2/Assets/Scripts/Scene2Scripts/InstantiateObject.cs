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

                
                
                SetActiveField(targetPosition.position, 0.1f);
                Destroy(gameObject);
                
                if (setActiveScript.randomCubePosition <= 42)//white
                {
                    Instantiate(GameAssets.i.effects[2], transform.position, quaternion.identity);
                    particleEffect.Play();
                }
                else if (43 <= setActiveScript.randomCubePosition && setActiveScript.randomCubePosition <= 84)//blue
                {
                    Instantiate(GameAssets.i.effects[0], transform.position, quaternion.identity);
                    particleEffect.Play();
                }
                else if(85 <= setActiveScript.randomCubePosition && setActiveScript.randomCubePosition <= 121)//red
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
