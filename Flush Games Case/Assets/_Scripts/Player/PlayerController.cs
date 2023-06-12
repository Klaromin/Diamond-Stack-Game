using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : Subject
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    private float _movementSpeed;
    private void Start()
    {
        _movementSpeed = 3f;


    }
    private void FixedUpdate()
    {
        Debug.Log("Horizontal: " + Math.Abs(_joystick.Horizontal) + " " + "Vertical: " + Math.Abs(_joystick.Vertical));
        _rb.velocity = new Vector3(_joystick.Horizontal * _movementSpeed, _rb.velocity.y, _joystick.Vertical * _movementSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
            
            if (Math.Abs(_joystick.Horizontal) > 0.6f || Math.Abs(_joystick.Vertical) > 0.6f)
            {
                NotifyObservers(PlayerActions.Run);
            }
            if (Math.Abs(_joystick.Horizontal) is < 0.6f and > 0 && Math.Abs(_joystick.Vertical) is < 0.6f and > 0)
            {
                NotifyObservers(PlayerActions.Walk);
            }
        }
        if (_joystick.Vertical == 0 && _joystick.Horizontal == 0)
        {
            NotifyObservers(PlayerActions.Idle);
        }

    }


}
