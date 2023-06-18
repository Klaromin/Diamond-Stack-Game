using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using StackGame.Collectable;
using StackGame.Managers;
using StackGame.Observer_Pattern;
using UnityEngine;

namespace StackGame.Player
{
    public class PlayerController : Subject
    {
        #region Serialize Fields
    
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _gemHolder;
        [SerializeField] private MeshCollider _meshCollider;
        [SerializeField] private Transform _sellLocation;
    
        #endregion
    
        #region Private Fields

        private float _sellTime = 0.5f;
        private float _elapsed;
        private float _movementSpeed;
        private List<Gem> _collectedGems = new List<Gem>();
        private List<Gem> _soldGems = new();
        private GameObject _lastObject;
        private float _verticalIncrementValue;
        private float _moveTime;

        #endregion
    
        #region EventHandlers

        public event EventHandler OnGemCollectedEvent;
        public event EventHandler<List<Gem>> OnPlayerInsideMarketEvent;
    
        #endregion 
    
        private void Start()
        {
        
            _lastObject = _gemHolder.gameObject;
            _movementSpeed = 3f;
            _verticalIncrementValue = 0.5f;
            _moveTime = 0.1f;
        }
        private void FixedUpdate()
        {
            _rb.velocity = new Vector3(_joystick.Horizontal * _movementSpeed, _rb.velocity.y, _joystick.Vertical * _movementSpeed);

            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rb.velocity);
            
                if (Math.Abs(_joystick.Horizontal) > 0.6f || Math.Abs(_joystick.Vertical) > 0.6f)
                {
                    NotifyObservers(PlayerMovement.Run);
                }
                if (Math.Abs(_joystick.Horizontal) is < 0.6f and > 0 && Math.Abs(_joystick.Vertical) is < 0.6f and > 0)
                {
                    NotifyObservers(PlayerMovement.Walk);
                }
            }
            if (_joystick.Vertical == 0 && _joystick.Horizontal == 0)
            {
                NotifyObservers(PlayerMovement.Idle);
            }

        }
    
        private void AddNewGemToStack(Gem gem)
        {
            if (gem.transform.localScale.x > 0.25f)
            {
                _collectedGems.Add(gem);
                gem.transform.SetParent(transform);
                gem.transform.rotation = transform.rotation;
                gem.transform.DOLocalMove(new Vector3(0f, _lastObject.transform.localPosition.y +
                                                          _verticalIncrementValue, _lastObject.transform.localPosition.z), _moveTime);
                gem.gameObject.layer = 7;
            
                _lastObject = gem.gameObject;
            }

        }

        private void SellGemFromStack()
        {
            if (_collectedGems.Count < 1)
                return;

            _elapsed += Time.fixedDeltaTime;
            if (_elapsed > _sellTime)
            {
                var currentGemToSell = _collectedGems.Last();
                currentGemToSell.transform.parent = null;
                currentGemToSell.transform.DOMove(_sellLocation.position, 3f).SetEase(Ease.Flash).OnComplete(() => _soldGems.Add(currentGemToSell)).OnComplete(() => Destroy(currentGemToSell.gameObject)).OnComplete(() => GemManager.Instance.CalculateTotalGem(currentGemToSell));
                _collectedGems.Remove(currentGemToSell);
                _soldGems.Add(currentGemToSell);
                OnPlayerInsideMarketEvent?.Invoke(this, _soldGems);
                _elapsed = 0;
            }
            _lastObject = _gemHolder.gameObject;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Collectable")
            {
                AddNewGemToStack(other.GetComponent<Gem>());
            
                OnGemCollectedEvent?.Invoke(this, EventArgs.Empty);
            }
            if (other.gameObject.tag == "Sell")
            {

            }
        }


        private  void OnTriggerStay(Collider other)
        {
        
            if (other.gameObject.tag == "Sell")
            {
            
                SellGemFromStack();
            
            
            }

        }



    }
}
