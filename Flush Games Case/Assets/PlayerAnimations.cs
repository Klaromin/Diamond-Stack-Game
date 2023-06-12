using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _playerSubject;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _playerSubject.AddObserver(this);
    }
    
    private void OnDisable()
    {
        _playerSubject.RemoveObserver(this);
    }
    public void OnNotify(PlayerActions action)
    {
        if (action == PlayerActions.Walk)
        {
            _animator.SetBool("Walk", true);
            _animator.SetBool("Run", false);
        }
        if (action == PlayerActions.Run)
        {
            _animator.SetBool("Walk", false);
            _animator.SetBool("Run", true);
        }
        if (action == PlayerActions.Idle)
        {
            _animator.SetBool("Walk", false);
            _animator.SetBool("Run", false);
        }
    }
}
