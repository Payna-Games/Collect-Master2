using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick _joystick;
 
   
    [SerializeField] private float _moveSpeed;
   
    private void FixedUpdate()
    {
         transform.Translate(new Vector3(_joystick.Horizontal * _moveSpeed, 0f ,_joystick.Vertical * _moveSpeed));
   
        //if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        // {
        //     transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        //_animator.SetBool("isRunning", true);
        // }
        // else
        //  _animator.SetBool("isRunning", false);
    }

}
