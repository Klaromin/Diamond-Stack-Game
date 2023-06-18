using UnityEngine;

namespace StackGame.UI
{
    public class PopUpSystem : MonoBehaviour
    {
    
        [SerializeField] private GameObject _popUpBox;
        [SerializeField] private Animator _popUpAnimator;

        public void PopUp()
        {
            _popUpBox.SetActive(true);
            _popUpAnimator.SetTrigger("pop");
        }
    }
}
