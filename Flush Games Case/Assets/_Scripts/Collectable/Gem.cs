using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _playerSubject;
    
    private void OnEnable()
    {
        _playerSubject.AddObserver(this);
    }
    
    private void OnDisable()
    {
        _playerSubject.RemoveObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNotify(PlayerActions action)
    {
        if (action == PlayerActions.Sell)
        {
            //Selling stuff
        }
    }
    public void OnNotify(PlayerMovement movement)
    {
        //Redundant
    }

}
