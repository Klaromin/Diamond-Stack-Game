using StackGame.Observer_Pattern;
using UnityEngine;

namespace StackGame.Player
{
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
        public void OnNotify(PlayerMovement movement)
        {
            Debug.Log(movement);
            if (movement == PlayerMovement.Walk)
            {
                _animator.SetBool("Walk", true);
                _animator.SetBool("Run", false);
            }
            if (movement == PlayerMovement.Run)
            {
                _animator.SetBool("Walk", false);
                _animator.SetBool("Run", true);
            }
            if (movement == PlayerMovement.Idle)
            {
                _animator.SetBool("Walk", false);
                _animator.SetBool("Run", false);
            }
        }
    }
}
