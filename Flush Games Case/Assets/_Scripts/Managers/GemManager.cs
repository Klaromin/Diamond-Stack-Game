using System.Collections.Generic;
using System.Linq;
using StackGame.Collectable;
using StackGame.Data;
using StackGame.Helper;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StackGame.Managers
{
    public class GemManager : MonoSingleton<GemManager>
    {
        private List<GemData> _gemDataList;
        private List<float> _gemAmountList;
        private List<Gem> _gemsToProcess;
        private float _totalGemValue;

        protected override void Awake()
        {
            GameManager.Instance.OnPlayerInsideMarketEvent += OnPlayerInsideMarket;
        
        }
    
        void Start()
        {
            _gemDataList = Resources.LoadAll<GemData>("Data").ToList();
            _gemAmountList = new List<float>();
            _gemsToProcess = new();
        
            foreach (var gemData in _gemDataList)
            {
                _gemAmountList.Add(0);
            }
        }
    
        private void OnPlayerInsideMarket(object sender, List<Gem> soldGemList)
        {
            foreach (var gem in soldGemList)
            {
                int gemTypeIndex = (int)gem.GetGemType();
                if (gemTypeIndex >= 0 && gemTypeIndex < _gemAmountList.Count)
                {
                    _gemAmountList[gemTypeIndex] += gem.GetGemPrice();
                    Debug.Log(gem);
                    _gemsToProcess.Add(gem);
                }
            }

            foreach (var gem in _gemsToProcess)
            {
                soldGemList.Remove(gem);
            }
        }

        public List<float> GetGemAmountList()
        {
            return _gemAmountList;
        }


        public GemData GetRandomData()
        {
            return _gemDataList[Random.Range(0, _gemDataList.Count)];
        }
    
        public List<GemData> GetGemDataList()
        {
            return _gemDataList;
        }

        public void CalculateTotalGem(Gem gem)
        {
            _totalGemValue += gem.GetGemPrice();
        }

    }
}
