using StackGame.Data;
using UnityEngine;
using UnityEngine.UI;

namespace StackGame.UI
{
    public class PopUpController : MonoBehaviour
    {
        #region SerializeFields
        
        [SerializeField] private Button _popUpButton;

        [SerializeField] private Button _closePopUpButton;

        [SerializeField] private GemUI _gemUI;

        [SerializeField] private Transform _parent;
    
        #endregion
        void Start()
        {
            InitGemUIs();
        }

        private void InitGemUIs()
        {
            foreach (var gemData in Resources.LoadAll<GemData>("Data"))
            {
                var go = Instantiate(_gemUI, _parent);
                go.SetData(gemData);
                go.Init();
            }
        }

    }
}
