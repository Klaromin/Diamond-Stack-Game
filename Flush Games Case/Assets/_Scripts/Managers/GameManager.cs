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
    
        public event EventHandler OnGemCollectedEvent;
        public event EventHandler<List<Gem>> OnPlayerInsideMarketEvent;
        protected override void Awake()
        {
            base.Awake();
            _playerController.OnGemCollectedEvent += OnGemCollected;
            _playerController.OnPlayerInsideMarketEvent += OnPlayerInsideMarket;
        }
        private void OnPlayerInsideMarket(object sender, List<Gem> e)
        {
            OnPlayerInsideMarketEvent?.Invoke(sender, e);
        }

        private void OnDisable()
        {
            RemoveEvents();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void AddEvents()
        {
            _playerController.OnGemCollectedEvent += OnGemCollected;
        }
        private void OnGemCollected(object sender, EventArgs e)
        {
            OnGemCollectedEvent?.Invoke(sender, EventArgs.Empty);
        }

        private void RemoveEvents()
        {
            _playerController.OnGemCollectedEvent -= OnGemCollected;
        }
    }
}
