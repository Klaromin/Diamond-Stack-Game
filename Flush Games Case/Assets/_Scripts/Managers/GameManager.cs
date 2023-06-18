using System;
using System.Collections.Generic;
using StackGame.Collectable;
using StackGame.Helper;
using StackGame.Player;
using UnityEngine;

namespace StackGame.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private PlayerController _playerController;
    
        
        public event EventHandler<List<Gem>> OnPlayerInsideMarketEvent;
        protected override void Awake()
        {
            base.Awake();
            _playerController.OnPlayerInsideMarketEvent += OnPlayerInsideMarket;
        }
        private void OnPlayerInsideMarket(object sender, List<Gem> e)
        {
            OnPlayerInsideMarketEvent?.Invoke(sender, e);
        }

    }
}
