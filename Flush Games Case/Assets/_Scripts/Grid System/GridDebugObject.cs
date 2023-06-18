using System.Collections.Generic;
using StackGame.Collectable;
using StackGame.Data;
using StackGame.Managers;
using TMPro;
using UnityEngine;

namespace StackGame.Grid_System
{
    public class GridDebugObject : MonoBehaviour //isim değiş.
    {

        [SerializeField] private TextMeshPro textMeshPro;

        private Gem _currentGem;
        private GridObject gridObject;
        private List<GemData> _gemDataList;

        private void Start()
        {
            _gemDataList = GemManager.Instance.GetGemDataList();
       
        }





        public void SetGridObject(GridObject gridObject)
        {
            this.gridObject = gridObject;
        }

        private void Update()
        {
            textMeshPro.text = gridObject.ToString();
        }
    }
}
