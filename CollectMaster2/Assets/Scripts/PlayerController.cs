using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private FloatingJoystick _joystick;
 
   
    public float _moveSpeed;
   
    private void FixedUpdate()
    {
         transform.Translate(new Vector3(_joystick.Horizontal * _moveSpeed, 0f ,_joystick.Vertical * _moveSpeed));
   
        
    }

}
