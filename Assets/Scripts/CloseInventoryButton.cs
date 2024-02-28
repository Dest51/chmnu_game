using UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CloseInventoryButton : MovePanel
    {
        [SerializeField] private Button _myButton = null;

        private void OnEnable()
        {
            _myButton.onClick.AddListener(Click);
        }

        private void OnDisable()
        {
            _myButton.onClick.RemoveListener(Click);
        }
        public void Click()
        {
            animator.SetBool("IsShowed", false);
            _isShowedInventory = false;

        }
    }
}
