using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTransform : MonoBehaviour
{
    public Transform copyTarget;

    private void FixedUpdate()
    {
        copyTarget.position = transform.position;
    }
}
