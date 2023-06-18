using StackGame.Data;
using StackGame.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StackGame.UI
{
    public class GemUI : MonoBehaviour
    {
        [SerializeField] private Image _gemImage;
        [SerializeField] private TextMeshProUGUI _gemAmountText;
        [SerializeField] private TextMeshProUGUI _gemTypeText;
        private GemData _gemData;
        void Start()
        {
        
        }
    
      
        void Update()
        {
            InitAmountText();
        }

        public void Init()
        {
            InitTypeText();
            InitAmountText();
            InitSprite();
        }
    
    

        public void InitTypeText()
        {
            _gemTypeText.text = _gemData.GemName;
        }

        public void InitAmountText()
        {
        
            int gemTypeIndex = (int)_gemData.GemType;
            if (gemTypeIndex >= 0 && gemTypeIndex < GemManager.Instance.GetGemAmountList().Count)
            {
                _gemAmountText.text = GemManager.Instance.GetGemAmountList()[gemTypeIndex].ToString();
            }
        }

        private void InitSprite()
        {
            _gemImage.sprite = _gemData.GemIcon;
        }

        public void SetData(GemData gemData)
        {
            _gemData = gemData;
        }


    }
}
