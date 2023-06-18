using System;
using StackGame.Collectable;
using StackGame.Managers;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

namespace StackGame.Grid_System
{
    public class GridObject : MonoBehaviour
    {
        [SerializeField] private Gem _gemPrefab;
        private bool IsFull;
        private GridSystem _gridSystem;
        private GridPosition _gridPosition;
        private Gem _spawnedGem;

        public GridObject(GridSystem gridSystem, GridPosition gridPosition)
        {
            _gridSystem = gridSystem;
            _gridPosition = gridPosition;
        }

        private void OnDisable()
        {
            RemoveEvents();
        }

        private void Start()
        {
            SpawnGem();
        }
        private async void SpawnGem()
        {
            await Task.Delay(2000);
            Vector3 offSet = new Vector3(0, 1, 0);
            _spawnedGem = Instantiate(_gemPrefab, transform.position + offSet, Quaternion.identity, this.transform);
            _spawnedGem.SetData(GemManager.Instance.GetRandomData());
            _spawnedGem.Init();
            AddEvents();
        }
    
        public override string ToString()
        {
            return _gridPosition.ToString() + "\n";
        }

        private void AddEvents()
        {
            _spawnedGem.OnGemCollectedEvent += OnGemCollected;
        }

        private void RemoveEvents()
        {
            _spawnedGem.OnGemCollectedEvent -= OnGemCollected;
        }

        private void OnGemCollected(object sender, EventArgs e)
        {
            RemoveEvents();
            SpawnGem();
        }

    }
}
